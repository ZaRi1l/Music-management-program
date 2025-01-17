using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class CircleButton : Button
{
    public CircleButton()
    {
        this.FlatStyle = FlatStyle.Flat;
        this.FlatAppearance.BorderSize = 0;
        this.Size = new Size(100, 100); // 기본 크기를 정사각형으로 설정하여 원형을 유지
        
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        // 원형 경로 생성
        using (GraphicsPath path = new GraphicsPath())
        {
            path.AddEllipse(0, 0, this.Width, this.Height);
            this.Region = new Region(path); // 버튼의 Region을 원형으로 설정
        }

        // 텍스트를 원형 가운데에 그리기
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        TextRenderer.DrawText(e.Graphics, this.Text, this.Font, ClientRectangle, this.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
    }
}
