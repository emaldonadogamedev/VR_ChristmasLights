using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.EditorTools;
using UnityEngine;
// EditorToolContextAttribute is what registers a context with the UI.
[EditorToolContext("Wobbly Transform Tools")]
// The icon path can also be used with packages. Ex "Packages/com.wobblestudio.wobblytools/Icons/Transform.png".
[Icon("Assets/Examples/Icons/TransformIcon.png")]
public class WobbleContext : EditorToolContext
{
    // Tool contexts can also implement an OnToolGUI function that is invoked before tools. This is a good place to
    // add any custom selection logic, for example.
    public override void OnToolGUI(EditorWindow _) { }
    protected override Type GetEditorToolType(Tool tool)
    {
        switch (tool)
        {
            // Return the type of tool to be used for Tool.Move. The Tool Manager will handle instantiating and
            // activating the tool.
            case Tool.Move:
                return typeof(WobblyMoveTool);
            // For any tools that are not implemented, return null to disable the tool in the menu.
            default:
                return null;
        }
    }
}
// Note that tools used by an EditorToolContext do not need to use EditorToolAttribute.
class WobblyMoveTool : EditorTool
{
    struct Selected
    {
        public Transform transform;
        public Vector3 localScale;
    }
    Vector3 m_Origin;
    List<Selected> m_Selected = new List<Selected>();
    void StartMove(Vector3 origin)
    {
        m_Origin = origin;
        m_Selected.Clear();
        foreach(var trs in Selection.transforms)
            m_Selected.Add(new Selected() { transform = trs, localScale = trs.localScale });
        Undo.RecordObjects(Selection.transforms, "Wobble Move Tool");
    }
    // This is silly example that oscillates the scale of the selected objects as they are moved.
    public override void OnToolGUI(EditorWindow _)
    {
        var evt = Event.current.type;
        var hot = GUIUtility.hotControl;
        EditorGUI.BeginChangeCheck();
        var p = Handles.PositionHandle(Tools.handlePosition, Tools.handleRotation);
        if (evt == EventType.MouseDown && hot != GUIUtility.hotControl)
            StartMove(p);
        if (EditorGUI.EndChangeCheck())
        {
            foreach (var selected in m_Selected)
            {
                selected.transform.position += (p - Tools.handlePosition);
                var scale = Vector3.one * (Mathf.Sin(Mathf.Abs(Vector3.Distance(m_Origin, p))) * .5f);
                selected.transform.localScale = selected.localScale + scale;
            }
        }
    }
}
