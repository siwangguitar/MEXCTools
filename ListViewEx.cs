using System.Runtime.InteropServices;

namespace MEXCTools
{
    public class ListViewEx : ListView
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int GetScrollPos(IntPtr hWnd, Orientation nBar);
        private Point StartPoint;
        public ListViewEx() : base() => DoubleBuffered = true;
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            var p = PointToClient(Cursor.Position);
            var lvi = GetItemAt(p.X, p.Y);
            if (lvi != null && lvi.GetSubItemAt(p.X, p.Y) != lvi.SubItems[0])
            {
                if (e.Button == MouseButtons.Left && Items.Count > 1)
                {
                    var vsp = GetScrollPos(Handle, Orientation.Vertical);
                    var yOffset = Font.Height * vsp;

                    StartPoint = new Point(e.X, e.Y + yOffset);
                }
            }
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (StartPoint != null) { StartPoint = Point.Empty; }

        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (StartPoint != Point.Empty && e.Button == MouseButtons.Left && Items.Count > 1)
            {
                var vsp = GetScrollPos(Handle, Orientation.Vertical);
                var fh = Font.Height;
                var yoffset = fh * vsp;

                var selRect = new Rectangle(Math.Min(StartPoint.X, e.Location.X),
                                           Math.Min(StartPoint.Y - yoffset, e.Location.Y),
                                           Math.Abs(e.Location.X - StartPoint.X),
                                           Math.Abs(e.Location.Y - StartPoint.Y + yoffset));

                var cr = ClientRectangle;

                //Toggle...
                foreach (var item in Items.Cast<ListViewItem>()
                    .Where(x => x.Bounds.IntersectsWith(cr)))
                    item.Selected = selRect.IntersectsWith(item.Bounds);

                //Scroll if needed...
                var p = PointToClient(Cursor.Position);
                var lvi = GetItemAt(p.X, p.Y);

                if (lvi == null) return;

                if (lvi.Index > 0 && (p.Y - lvi.Bounds.Height) <= fh)
                    Items[lvi.Index - 1].EnsureVisible();
                else if (lvi.Index < Items.Count - 1 && (p.Y + lvi.Bounds.Height) > (Height - fh))
                    Items[lvi.Index + 1].EnsureVisible();
            }
        }
    }
}
