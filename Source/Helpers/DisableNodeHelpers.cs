using Godot;

namespace Shooter.Source.Helpers
{
    public static class DisableNodeHelpers
    {
        public static void DisableNodeIncludingChildren(Node node)
        {
            foreach(Node child in node.GetChildren())
            {
                DisableNodeIncludingChildren(child);
            }

            if(node is Node2D node2D)
            {
                node2D.Visible = false;
            }
            node.SetProcess(false);
        }

        public static void EnableNodeIncludingChildren(Node node)
        {
            foreach(Node child in node.GetChildren())
            {
                EnableNodeIncludingChildren(child);
            }

            if(node is Node2D node2D)
            {
                node2D.Visible = true;
            }
            
            node.SetProcess(true);
        }
    }
}