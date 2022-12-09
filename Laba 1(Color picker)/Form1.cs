using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using ColorHelper;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net.WebSockets;

namespace ColorPicker
{
    public partial class Form1 : Form
    {
        bool specBool = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void colorChange()
        {
            byte r = (byte)Convert.ToInt16(rgbRValue.Text);
            byte g = (byte)Convert.ToInt16(rgbGValue.Text);
            byte b = (byte)Convert.ToInt16(rgbBValue.Text);
            selectedColor.BackColor = Color.FromArgb(r, g, b);
        }
        private void yuvValuesChangedEvent()
        {
            double y = (double)(Convert.ToInt32(yuvYValue.Text));
            double u = (double)(Convert.ToInt32(yuvUValue.Text));
            double v = (double)(Convert.ToInt32(yuvVValue.Text));
            YUV yuv = new YUV(y, u, v);
            RGB rgb = ColorHelper.ColorConverter.YuvToRgb(yuv);
            HSL hsl = ColorHelper.ColorConverter.YuvToHsl(yuv);
            HSV hsv = ColorHelper.ColorConverter.YuvToHsv(yuv);
            XYZ xyz = ColorHelper.ColorConverter.YuvToXyz(yuv);
            CMYK cmyk = ColorHelper.ColorConverter.YuvToCmyk(yuv);

            rgbRValue.Text = rgb.R.ToString();
            rgbGValue.Text = rgb.G.ToString();
            rgbBValue.Text = rgb.B.ToString();
            rgbRTrackBar.Value = rgb.R;
            rgbGTrackBar.Value = rgb.G;
            rgbBTrackBar.Value = rgb.B;

            hslHValue.Text = hsl.H.ToString();
            hslSValue.Text = hsl.S.ToString();
            hslLValue.Text = hsl.L.ToString();
            hslHTrackBar.Value = hsl.H;
            hslSTrackBar.Value = hsl.S;
            hslLTrackBar.Value = hsl.L;

            hsvHValue.Text = hsv.H.ToString();
            hsvSValue.Text = hsv.S.ToString();
            hsvVValue.Text = hsv.V.ToString();
            hsvHTrackBar.Value = hsv.H;
            hsvSTrackBar.Value = hsv.S;
            hsvVTrackBar.Value = hsv.V;

            xyzXValue.Text = xyz.X.ToString();
            xyzYValue.Text = xyz.Y.ToString();
            xyzZValue.Text = xyz.Z.ToString();
            xyzXtrackBar.Value = (int)xyz.X;
            xyzYtrackBar.Value = (int)xyz.Y;
            xyzZtrackBar.Value = (int)xyz.Z;

            CmykCValue.Text = cmyk.C.ToString();
            CmykMValue.Text = cmyk.M.ToString();
            CmykYValue.Text = cmyk.Y.ToString();
            CmykBValue.Text = cmyk.K.ToString();
            CmykCtrackBar.Value = (int)cmyk.C;
            CmykMtrackBar.Value = (int)cmyk.M;
            CmykYtrackBar.Value = (int)cmyk.Y;
            CmykBtrackBar.Value = (int)cmyk.K;

            colorChange();
            specBool = true;
        }
        private void cmykValuesChangedEvent()
        {
            byte c = (byte)Convert.ToInt16(CmykCValue.Text);
            byte m = (byte)Convert.ToInt16(CmykMValue.Text);
            byte y = (byte)Convert.ToInt16(CmykYValue.Text);
            byte k = (byte)Convert.ToInt16(CmykBValue.Text);
            CMYK cmyk = new CMYK(c, m, y, k);
            RGB rgb = ColorHelper.ColorConverter.CmykToRgb(cmyk);
            HSL hsl = ColorHelper.ColorConverter.CmykToHsl(cmyk);
            HSV hsv = ColorHelper.ColorConverter.CmykToHsv(cmyk);
            XYZ xyz = ColorHelper.ColorConverter.CmykToXyz(cmyk);
            YUV yuv = ColorHelper.ColorConverter.CmykToYuv(cmyk);


            yuvYValue.Text = (yuv.Y * 150).ToString();
            yuvUValue.Text = (yuv.U * 150).ToString();
            yuvVValue.Text = (yuv.V * 150).ToString();
            yuvYtrackBar.Value = (int)yuv.Y;
            yuvUtrackBar.Value = (int)yuv.U * 150;
            yuvVtrackBar.Value = (int)yuv.V * 150;

            rgbRValue.Text = rgb.R.ToString();
            rgbGValue.Text = rgb.G.ToString();
            rgbBValue.Text = rgb.B.ToString();
            rgbRTrackBar.Value = rgb.R;
            rgbGTrackBar.Value = rgb.G;
            rgbBTrackBar.Value = rgb.B;

            hslHValue.Text = hsl.H.ToString();
            hslSValue.Text = hsl.S.ToString();
            hslLValue.Text = hsl.L.ToString();
            hslHTrackBar.Value = hsl.H;
            hslSTrackBar.Value = hsl.S;
            hslLTrackBar.Value = hsl.L;

            hsvHValue.Text = hsv.H.ToString();
            hsvSValue.Text = hsv.S.ToString();
            hsvVValue.Text = hsv.V.ToString();
            hsvHTrackBar.Value = hsv.H;
            hsvSTrackBar.Value = hsv.S;
            hsvVTrackBar.Value = hsv.V;

            xyzXValue.Text = xyz.X.ToString();
            xyzYValue.Text = xyz.Y.ToString();
            xyzZValue.Text = xyz.Z.ToString();
            xyzXtrackBar.Value = (int)xyz.X;
            xyzYtrackBar.Value = (int)xyz.Y;
            xyzZtrackBar.Value = (int)xyz.Z;



            colorChange();
            specBool = true;
        }
        private void rgbValuesChangedEvent()
        {
            byte r = (byte)Convert.ToInt16(rgbRValue.Text);
            byte g = (byte)Convert.ToInt16(rgbGValue.Text);
            byte b = (byte)Convert.ToInt16(rgbBValue.Text);
            RGB rgb = new RGB(r, g, b);
            HSL hsl = ColorHelper.ColorConverter.RgbToHsl(rgb);
            HSV hsv = ColorHelper.ColorConverter.RgbToHsv(rgb);
            XYZ xyz = ColorHelper.ColorConverter.RgbToXyz(rgb);
            CMYK cmyk = ColorHelper.ColorConverter.RgbToCmyk(rgb);
            YUV yuv = ColorHelper.ColorConverter.RgbToYuv(rgb);


            yuvYValue.Text = (yuv.Y * 255).ToString();
            yuvUValue.Text = (yuv.U * 112).ToString();
            yuvVValue.Text = (yuv.V * 157).ToString();
            yuvYtrackBar.Value = (int)yuvYValue.Value;
            yuvUtrackBar.Value = (int)yuvUValue.Value;
            yuvVtrackBar.Value = (int)yuvVValue.Value;

            hslHValue.Text = hsl.H.ToString();
            hslSValue.Text = hsl.S.ToString();
            hslLValue.Text = hsl.L.ToString();
            hslHTrackBar.Value = hsl.H;
            hslSTrackBar.Value = hsl.S;
            hslLTrackBar.Value = hsl.L;

            hsvHValue.Text = hsv.H.ToString();
            hsvSValue.Text = hsv.S.ToString();
            hsvVValue.Text = hsv.V.ToString();
            hsvHTrackBar.Value = hsv.H;
            hsvSTrackBar.Value = hsv.S;
            hsvVTrackBar.Value = hsv.V;

            xyzXValue.Text = xyz.X.ToString();
            xyzYValue.Text = xyz.Y.ToString();
            xyzZValue.Text = xyz.Z.ToString();
            xyzXtrackBar.Value = (int)xyz.X;
            xyzYtrackBar.Value = (int)xyz.Y;
            xyzZtrackBar.Value = (int)xyz.Z;

            CmykCValue.Text = cmyk.C.ToString();
            CmykMValue.Text = cmyk.M.ToString();
            CmykYValue.Text = cmyk.Y.ToString();
            CmykBValue.Text = cmyk.K.ToString();
            CmykCtrackBar.Value = (int)cmyk.C;
            CmykMtrackBar.Value = (int)cmyk.M;
            CmykYtrackBar.Value = (int)cmyk.Y;
            CmykBtrackBar.Value = (int)cmyk.K;

            colorChange();
            specBool = true;
        }
        private void xyzValuesChangedEvent()
        {
            byte x = (byte)Convert.ToInt16(xyzXValue.Text);
            byte y = (byte)Convert.ToInt16(xyzYValue.Text);
            byte z = (byte)Convert.ToInt16(xyzZValue.Text);
            XYZ xyz = new XYZ(x, y, z);
            RGB rgb = ColorHelper.ColorConverter.XyzToRgb(xyz);
            HSV hsv = ColorHelper.ColorConverter.XyzToHsv(xyz);
            HSL hsl = ColorHelper.ColorConverter.XyzToHsl(xyz);
            CMYK cmyk = ColorHelper.ColorConverter.XyzToCmyk(xyz);
            YUV yuv = ColorHelper.ColorConverter.XyzToYuv(xyz);



            yuvYValue.Text = (yuv.Y * 255).ToString();
            yuvUValue.Text = (yuv.U * 112).ToString();
            yuvVValue.Text = (yuv.V * 157).ToString();
            yuvYtrackBar.Value = (int)yuvYValue.Value;
            yuvUtrackBar.Value = (int)yuvUValue.Value;
            yuvVtrackBar.Value = (int)yuvVValue.Value;
            hsvHValue.Text = hsv.H.ToString();
            hsvSValue.Text = hsv.S.ToString();
            hsvVValue.Text = hsv.V.ToString();
            hsvHTrackBar.Value = hsv.H;
            hsvSTrackBar.Value = hsv.S;
            hsvVTrackBar.Value = hsv.V;

            rgbRValue.Text = rgb.R.ToString();
            rgbGValue.Text = rgb.G.ToString();
            rgbBValue.Text = rgb.B.ToString();
            rgbRTrackBar.Value = rgb.R;
            rgbGTrackBar.Value = rgb.G;
            rgbBTrackBar.Value = rgb.B;

            hslHValue.Text = hsl.H.ToString();
            hslSValue.Text = hsl.S.ToString();
            hslLValue.Text = hsl.L.ToString();
            hslHTrackBar.Value = hsl.H;
            hslSTrackBar.Value = hsl.S;
            hslLTrackBar.Value = hsl.L;

            CmykCValue.Text = cmyk.C.ToString();
            CmykMValue.Text = cmyk.M.ToString();
            CmykYValue.Text = cmyk.Y.ToString();
            CmykBValue.Text = cmyk.K.ToString();
            CmykCtrackBar.Value = (int)cmyk.C;
            CmykMtrackBar.Value = (int)cmyk.M;
            CmykYtrackBar.Value = (int)cmyk.Y;
            CmykBtrackBar.Value = (int)cmyk.K;
            colorChange();
            specBool = true;
        }

        private void hslValuesChangedEvent()
        {
            byte h = (byte)Convert.ToInt16(hslHValue.Text);
            byte s = (byte)Convert.ToInt16(hslSValue.Text);
            byte l = (byte)Convert.ToInt16(hslLValue.Text);
            HSL hsl = new HSL(h, s, l);
            RGB rgb = ColorHelper.ColorConverter.HslToRgb(hsl);
            HSV hsv = ColorHelper.ColorConverter.HslToHsv(hsl);
            XYZ xyz = ColorHelper.ColorConverter.RgbToXyz(rgb);
            CMYK cmyk = ColorHelper.ColorConverter.RgbToCmyk(rgb);
            YUV yuv = ColorHelper.ColorConverter.RgbToYuv(rgb);


            yuvYValue.Text = (yuv.Y * 255).ToString();
            yuvUValue.Text = (yuv.U * 112).ToString();
            yuvVValue.Text = (yuv.V * 157).ToString();
            yuvYtrackBar.Value = (int)yuvYValue.Value;
            yuvUtrackBar.Value = (int)yuvUValue.Value;
            yuvVtrackBar.Value = (int)yuvVValue.Value;

            hsvHValue.Text = hsv.H.ToString();
            hsvSValue.Text = hsv.S.ToString();
            hsvVValue.Text = hsv.V.ToString();
            hsvHTrackBar.Value = hsv.H;
            hsvSTrackBar.Value = hsv.S;
            hsvVTrackBar.Value = hsv.V;

            rgbRValue.Text = rgb.R.ToString();
            rgbGValue.Text = rgb.G.ToString();
            rgbBValue.Text = rgb.B.ToString();
            rgbRTrackBar.Value = rgb.R;
            rgbGTrackBar.Value = rgb.G;
            rgbBTrackBar.Value = rgb.B;

            xyzXValue.Text = xyz.X.ToString();
            xyzYValue.Text = xyz.Y.ToString();
            xyzZValue.Text = xyz.Z.ToString();
            xyzXtrackBar.Value = (int)xyz.X;
            xyzYtrackBar.Value = (int)xyz.Y;
            xyzZtrackBar.Value = (int)xyz.Z;

            CmykCValue.Text = cmyk.C.ToString();
            CmykMValue.Text = cmyk.M.ToString();
            CmykYValue.Text = cmyk.Y.ToString();
            CmykBValue.Text = cmyk.K.ToString();
            CmykCtrackBar.Value = (int)cmyk.C;
            CmykMtrackBar.Value = (int)cmyk.M;
            CmykYtrackBar.Value = (int)cmyk.Y;
            CmykBtrackBar.Value = (int)cmyk.K;
            colorChange();
            specBool = true;
        }

        private void hsvValuesChangedEvent()
        {
            byte h = (byte)Convert.ToInt16(hsvHValue.Text);
            byte s = (byte)Convert.ToInt16(hsvSValue.Text);
            byte v = (byte)Convert.ToInt16(hsvVValue.Text);
            HSV hsv = new HSV(h, s, v);
            RGB rgb = ColorHelper.ColorConverter.HsvToRgb(hsv);
            HSL hsl = ColorHelper.ColorConverter.HsvToHsl(hsv);
            XYZ xyz = ColorHelper.ColorConverter.RgbToXyz(rgb);
            CMYK cmyk = ColorHelper.ColorConverter.RgbToCmyk(rgb);
            YUV yuv = ColorHelper.ColorConverter.RgbToYuv(rgb);



            yuvYValue.Text = (yuv.Y * 255).ToString();
            yuvUValue.Text = (yuv.U * 112).ToString();
            yuvVValue.Text = (yuv.V * 157).ToString();
            yuvYtrackBar.Value = (int)yuvYValue.Value;
            yuvUtrackBar.Value = (int)yuvUValue.Value;
            yuvVtrackBar.Value = (int)yuvVValue.Value;

            rgbRValue.Text = rgb.R.ToString();
            rgbGValue.Text = rgb.G.ToString();
            rgbBValue.Text = rgb.B.ToString();
            rgbRTrackBar.Value = rgb.R;
            rgbGTrackBar.Value = rgb.G;
            rgbBTrackBar.Value = rgb.B;

            hslHValue.Text = hsl.H.ToString();
            hslSValue.Text = hsl.S.ToString();
            hslLValue.Text = hsl.L.ToString();
            hslHTrackBar.Value = hsl.H;
            hslSTrackBar.Value = hsl.S;
            hslLTrackBar.Value = hsl.L;

            xyzXValue.Text = xyz.X.ToString();
            xyzYValue.Text = xyz.Y.ToString();
            xyzZValue.Text = xyz.Z.ToString();
            xyzXtrackBar.Value = (int)xyz.X;
            xyzYtrackBar.Value = (int)xyz.Y;
            xyzZtrackBar.Value = (int)xyz.Z;

            CmykCValue.Text = cmyk.C.ToString();
            CmykMValue.Text = cmyk.M.ToString();
            CmykYValue.Text = cmyk.Y.ToString();
            CmykBValue.Text = cmyk.K.ToString();
            CmykCtrackBar.Value = (int)cmyk.C;
            CmykMtrackBar.Value = (int)cmyk.M;
            CmykYtrackBar.Value = (int)cmyk.Y;
            CmykBtrackBar.Value = (int)cmyk.K;

            colorChange();

            specBool = true;
        }

        private void ColorSpectre_MouseDown(object sender, MouseEventArgs e)
        {
            Bitmap pixelData = (Bitmap) colorSpectre.Image;
            Color clr = pixelData.GetPixel(e.X, e.Y);

            rgbRValue.Text = clr.R.ToString();
            rgbGValue.Text = clr.G.ToString();
            rgbBValue.Text = clr.B.ToString();
            rgbRTrackBar.Value = clr.R;
            rgbGTrackBar.Value = clr.G;
            rgbBTrackBar.Value = clr.B;

            RGB rgb = new RGB(clr.R, clr.G, clr.B);
            HSL hsl = ColorHelper.ColorConverter.RgbToHsl(rgb);
            HSV hsv = ColorHelper.ColorConverter.RgbToHsv(rgb);
            XYZ xyz = ColorHelper.ColorConverter.RgbToXyz(rgb);
            CMYK cmyk = ColorHelper.ColorConverter.RgbToCmyk(rgb);
            YUV yuv = ColorHelper.ColorConverter.RgbToYuv(rgb);


            yuvYValue.Text = (yuv.Y * 255).ToString();
            yuvUValue.Text = (yuv.U * 112).ToString();
            yuvVValue.Text = (yuv.V * 157).ToString();
            yuvYtrackBar.Value = (int)yuvYValue.Value;
            yuvUtrackBar.Value = (int)yuvUValue.Value;
            yuvVtrackBar.Value = (int)yuvVValue.Value;

            hslHValue.Text = hsl.H.ToString();
            hslSValue.Text = hsl.S.ToString();
            hslLValue.Text = hsl.L.ToString();
            hslHTrackBar.Value = hsl.H;
            hslSTrackBar.Value = hsl.S;
            hslLTrackBar.Value = hsl.L;

            hsvHValue.Text = hsv.H.ToString();
            hsvSValue.Text = hsv.S.ToString();
            hsvVValue.Text = hsv.V.ToString();
            hsvHTrackBar.Value = hsv.H;
            hsvSTrackBar.Value = hsv.S;
            hsvVTrackBar.Value = hsv.V;

            xyzXValue.Text = xyz.X.ToString();
            xyzYValue.Text = xyz.Y.ToString();
            xyzZValue.Text = xyz.Z.ToString();
            xyzXtrackBar.Value = (int)xyz.X;
            xyzYtrackBar.Value = (int)xyz.Y;
            xyzZtrackBar.Value = (int)xyz.Z;
            CmykCValue.Text = cmyk.C.ToString();
            CmykMValue.Text = cmyk.M.ToString();
            CmykYValue.Text = cmyk.Y.ToString();
            CmykBValue.Text = cmyk.K.ToString();
            CmykCtrackBar.Value = (int)cmyk.C;
            CmykMtrackBar.Value = (int)cmyk.M;
            CmykYtrackBar.Value = (int)cmyk.Y;
            CmykBtrackBar.Value = (int)cmyk.K;
            selectedColor.BackColor = clr;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rgbRTrackBar_Scroll(object sender, EventArgs e)
        {
            rgbRValue.Text = rgbRTrackBar.Value.ToString();
            if (specBool)
            {
                specBool = false;
                rgbValuesChangedEvent();
            }
        }

        private void rgbGTrackBar_Scroll(object sender, EventArgs e)
        {
            rgbGValue.Text = rgbGTrackBar.Value.ToString();
            if (specBool)
            {
                specBool = false;
                rgbValuesChangedEvent();
            }
        }

        private void rgbBTrackBar_Scroll(object sender, EventArgs e)
        {
            rgbBValue.Text = rgbBTrackBar.Value.ToString();
            if (specBool)
            {
                specBool = false;
                rgbValuesChangedEvent();
            }
        }

        private void rgbRValue_ValueChanged(object sender, EventArgs e)
        {
            rgbRTrackBar.Value = (int)rgbRValue.Value;
            if (specBool)
            {
                specBool = false;
                rgbValuesChangedEvent();
            }
        }

        private void rgbGValue_ValueChanged(object sender, EventArgs e)
        {
            rgbGTrackBar.Value = (int)rgbGValue.Value;
            if (specBool)
            {
                specBool = false;
                rgbValuesChangedEvent();
            }
        }

        private void rgbBValue_ValueChanged(object sender, EventArgs e)
        {
            rgbBTrackBar.Value = (int)rgbBValue.Value;
            if (specBool)
            {
                specBool = false;
                rgbValuesChangedEvent();
            }
        }

        private void hslHTrackBar_Scroll(object sender, EventArgs e)
        {
            hslHValue.Text = hslHTrackBar.Value.ToString();
            if (specBool)
            {
                specBool = false;
                hslValuesChangedEvent();
            }
        }

        private void hslSTrackBar_Scroll(object sender, EventArgs e)
        {
            hslSValue.Text = hslSTrackBar.Value.ToString();
            if (specBool)
            {
                specBool = false;
                hslValuesChangedEvent();
            }
        }

        private void hslLTrackBar_Scroll(object sender, EventArgs e)
        {
            hslLValue.Text = hslLTrackBar.Value.ToString();
            if (specBool)
            {
                specBool = false;
                hslValuesChangedEvent();
            }
        }

        private void hslHValue_ValueChanged(object sender, EventArgs e)
        {
            hslHTrackBar.Value = (int)hslHValue.Value;
            if (specBool)
            {
                specBool = false;
                hslValuesChangedEvent();
            }
        }

        private void hslSValue_ValueChanged(object sender, EventArgs e)
        {
            hslSTrackBar.Value = (int)hslSValue.Value;
            if (specBool)
            {
                specBool = false;
                hslValuesChangedEvent();
            }
        }

        private void hslLValue_ValueChanged(object sender, EventArgs e)
        {
            hslLTrackBar.Value = (int)hslLValue.Value;
            if (specBool)
            {
                specBool = false;
                hslValuesChangedEvent();
            }
        }



        private void hsvHTrackBar_Scroll(object sender, EventArgs e)
        {
            hsvHValue.Text = hsvHTrackBar.Value.ToString();
            if (specBool)
            {
                specBool = false;
                hsvValuesChangedEvent();
            }
        }

        private void hsvSTrackBar_Scroll(object sender, EventArgs e)
        {
            hsvSValue.Text = hsvSTrackBar.Value.ToString();
            if (specBool)
            {
                specBool = false;
                hsvValuesChangedEvent();
            }
        }

        private void hsvVTrackBar_Scroll(object sender, EventArgs e)
        {
            hsvVValue.Text = hsvVTrackBar.Value.ToString();
            if (specBool)
            {
                specBool = false;
                hsvValuesChangedEvent();
            }
        }

        private void hsvHValue_ValueChanged(object sender, EventArgs e)
        {
            hsvHTrackBar.Value = (int)hsvHValue.Value;
            if (specBool)
            {
                specBool = false;
                hsvValuesChangedEvent();
            }
        }

        private void hsvSValue_ValueChanged(object sender, EventArgs e)
        {
            hsvSTrackBar.Value = (int)hsvSValue.Value;
            if (specBool)
            {
                specBool = false;
                hsvValuesChangedEvent();
            }
        }

        private void hsvVValue_ValueChanged(object sender, EventArgs e)
        {
            hsvVTrackBar.Value = (int)hsvVValue.Value;
            if (specBool)
            {
                specBool = false;
                hsvValuesChangedEvent();
            }
        }

        private void hslBox_Enter(object sender, EventArgs e)
        {

        }

        private void rgbRLabel_Click(object sender, EventArgs e)
        {

        }

        private void xyzXtrackBar_Scroll(object sender, EventArgs e)
        {
            xyzXValue.Text = xyzXtrackBar.Value.ToString();
            if (specBool)
            {
                specBool = false;
                xyzValuesChangedEvent();
            }
        }

        private void xyzYtrackBar_Scroll(object sender, EventArgs e)
        {
            xyzYValue.Text = xyzYtrackBar.Value.ToString();
            if (specBool)
            {
                specBool = false;
                xyzValuesChangedEvent();
            }
        }
        private void xyzXValue_ValueChanged(object sender, EventArgs e)
        {
            xyzXtrackBar.Value = (int)xyzXValue.Value;
            if (specBool)
            {
                specBool = false;
                xyzValuesChangedEvent();
            }
        }

        private void xyzYValue_ValueChanged(object sender, EventArgs e)
        {
            xyzYtrackBar.Value = (int)xyzYValue.Value;
            if (specBool)
            {
                specBool = false;
                xyzValuesChangedEvent();
            }
        }

        private void xyzZValue_ValueChanged(object sender, EventArgs e)
        {
            xyzZtrackBar.Value = (int)xyzZValue.Value;
            if (specBool)
            {
                specBool = false;
                xyzValuesChangedEvent();
            }
        }

        private void xyzZtrackBar_Scroll_1(object sender, EventArgs e)
        {
            xyzZValue.Text = xyzZtrackBar.Value.ToString();
            if (specBool)
            {
                specBool = false;
                xyzValuesChangedEvent();
            }
        }

   
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void hsvBox_Enter(object sender, EventArgs e)
        {

        }

        private void CmykCtrackBar_Scroll(object sender, EventArgs e)
        {
            CmykCValue.Text = CmykCtrackBar.Value.ToString();
            if (specBool)
            {
                specBool = false;
                cmykValuesChangedEvent();
            }
        }

        private void CmykMtrackBar_Scroll(object sender, EventArgs e)
        {
            CmykMValue.Text = CmykMtrackBar.Value.ToString();
            if (specBool)
            {
                specBool = false;
                cmykValuesChangedEvent();
            }
        }

        private void CmykYtrackBar_Scroll(object sender, EventArgs e)
        {
            CmykYValue.Text = CmykYtrackBar.Value.ToString();
            if (specBool)
            {
                specBool = false;
                cmykValuesChangedEvent();
            }
        }

        private void CmykBtrackBar_Scroll(object sender, EventArgs e)
        {
            CmykBValue.Text = CmykBtrackBar.Value.ToString();
            if (specBool)
            {
                specBool = false;
                cmykValuesChangedEvent();
            }
        }

        private void CmykCValue_ValueChanged(object sender, EventArgs e)
        {
            CmykCtrackBar.Value = (int)CmykCValue.Value;
            if (specBool)
            {
                specBool = false;
                cmykValuesChangedEvent();
            }
        }

        private void CmykMValue_ValueChanged(object sender, EventArgs e)
        {
            CmykCtrackBar.Value = (int)CmykCValue.Value;
            if (specBool)
            {
                specBool = false;
                cmykValuesChangedEvent();
            }
        }

        private void CmykYValue_ValueChanged(object sender, EventArgs e)
        {
            CmykYtrackBar.Value = (int)CmykYValue.Value;
            if (specBool)
            {
                specBool = false;
                cmykValuesChangedEvent();
            }
        }

        private void CmykBValue_ValueChanged(object sender, EventArgs e)
        {
            CmykBtrackBar.Value = (int)CmykBValue.Value;
            if (specBool)
            {
                specBool = false;
                cmykValuesChangedEvent();
            }
        }

        private void CmykMLable_Click(object sender, EventArgs e)
        {

        }

        private void CmykBLable_Click(object sender, EventArgs e)
        {

        }

        private void yuvYtrackBar_Scroll(object sender, EventArgs e)
        {
            yuvYValue.Text = yuvYtrackBar.Value.ToString();
            if (specBool)
            {
                specBool = false;
                yuvValuesChangedEvent();
            }
        }

        private void yuvUtrackBar_Scroll(object sender, EventArgs e)
        {
            yuvUValue.Text = yuvUtrackBar.Value.ToString();
            if (specBool)
            {
                specBool = false;
                yuvValuesChangedEvent();
            }
        }

        private void yuvVtrackBar_Scroll(object sender, EventArgs e)
        {
            yuvVValue.Text = yuvVtrackBar.Value.ToString();
            if (specBool)
            {
                specBool = false;
                yuvValuesChangedEvent();
            }
        }

        private void yuvYValue_ValueChanged(object sender, EventArgs e)
        {
            yuvYtrackBar.Value = (int)yuvYValue.Value;
            if (specBool)
            {
                specBool = false;
                yuvValuesChangedEvent();
            }
        }

        private void yuvUValue_ValueChanged(object sender, EventArgs e)
        {
            yuvUtrackBar.Value = (int)yuvUValue.Value;
            if (specBool)
            {
                specBool = false;
                yuvValuesChangedEvent();
            }
        }

        private void yuvVValue_ValueChanged(object sender, EventArgs e)
        {
            yuvVtrackBar.Value = (int)yuvVValue.Value;
            if (specBool)
            {
                specBool = false;
                yuvValuesChangedEvent();
            }
        }
    }
}


