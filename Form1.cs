using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void gerar_Click(object sender, EventArgs e)
        {
            string formula;
            double a, v0, t, r, v, s0, s, aux, aux2, ds;
            switch (formulas.SelectedIndex)
            {
                    //velocidade...................................................................................
                case 0:
                    a = Convert.ToDouble(aceleracao.Text);
                    v0 = Convert.ToDouble(velocidadei.Text);
                    t = Convert.ToDouble(tempo.Text);
                    //resultado
                    r = v0 + (a * t);
                    result.Text = Convert.ToString(r);

                    //formula
                    formula = String.Format("V = v0 + (a * t)\nV = {0} + ({1} * {2})\nV = {0} + {3}", v0, a, t, a*t);
                    formulai.Text = formula;
                    break;

                    //velocidade inicial..........................................................................
                case 1:
                    a = Convert.ToDouble(aceleracao.Text);
                    t = Convert.ToDouble(tempo.Text);
                    v = Convert.ToDouble(velocidade.Text);
                    //resultado
                    aux = a * t;
                    if (aux <= 0)
                    {
                        aux = -aux;
                        r = v + aux;
                        formula = String.Format("V = v0 + (a * t)\n{0} = V0 + ({1} * {2})\n{0} = V0{3}\n {0}+{4}=v0", v, a, t, a*t, aux);
                        formulai.Text = formula;
                    }
                    else
                    {
                        r = v - aux;
                        formula = String.Format("V = v0 + (a * t)\n{0} = V0 + ({1} * {2})\n{0} = V0+{3}\n {0}-{3}=v0", v, a, t, a * t);
                        formulai.Text = formula;
                    }

                    result.Text = Convert.ToString(r);
                    break;

                    //aceleraçao.............................................................................
                case 2:
                    v0 = Convert.ToDouble(velocidadei.Text);
                    t = Convert.ToDouble(tempo.Text);
                    v = Convert.ToDouble(velocidade.Text);
                    //formula
                    if (v0 <= 0)
                    {
                        aux = v0;
                        v0 = -v0;
                        r = (v + v0)/t;
                        formula = String.Format("V = v0 + (a * t)\n{0} = {1} + (a * {2})\n{0}+{4} = {2}a\n {3}/{2}=a", v, aux, t, v+v0, v0);
                        formulai.Text = formula;
                    }
                    else
                    {
                        r = (v - v0) / t;
                        formula = String.Format("V = v0 + (a * t)\n{0} = {1} + (a * {2})\n{0}-{1} = {2}a\n {3}/{2}=a", v, v0, t, v - v0);
                        formulai.Text = formula;
                    }
                    //resultado
                    result.Text = Convert.ToString(r);
                    break;

                //tempo..................................................................................
                case 3:
                    v0 = Convert.ToDouble(velocidadei.Text);
                    a = Convert.ToDouble(aceleracao.Text);
                    v = Convert.ToDouble(velocidade.Text);
                    //formula
                    if (v0 <= 0)
                    {
                        aux = v0;
                        v0 = -v0;
                        r = (v + v0) / a;
                        formula = String.Format("V = v0 + (a * t)\n{0} = {1} + ({2} * t)\n{0}+{4} = t{2}\n {3}/{2}=t", v, aux, a, v + v0, v0);
                        formulai.Text = formula;
                    }
                    else
                    {
                        r = (v - v0) / a;
                        formula = String.Format("V = v0 + (a * t)\n{0} = {1} + ({2} * t)\n{0}-{1} = t{2}\n {3}/{2}=t", v, v0, a, v - v0);
                        formulai.Text = formula;
                    }
                    //resultado
                    result.Text = Convert.ToString(r);
                    break;

                //Posiçao..................................................................................
                case 4:
                    s0 = Convert.ToDouble(posicaoi.Text);
                    v0 = Convert.ToDouble(velocidadei.Text);
                    a = Convert.ToDouble(aceleracao.Text);
                    t = Convert.ToDouble(tempo.Text);
                    //formula
                    r = s0+(v0*t)+(a*(t*t))/2;
                    formula = String.Format("S=S0+v0*t+a*t²/2\n" +
                        "                    S={0}+{1}*{2}+{3}*{2}²/2\n" +
                        "                    S={0}+{4}+{3}*{5}/2\n" +
                        "                    S={6}+{7}/2\n" +
                        "                    S={6}+{8}\n", s0, v0, t, a, v0*t, t*t, s0+(v0*t), a*(t*t), ((a*(t*t))/2));
                        formulai.Text = formula;
                    //resultado
                    result.Text = Convert.ToString(r);
                    break;

                //Posiçao Inicial............................................................................
                case 5:
                    s = Convert.ToDouble(posicao.Text);
                    v0 = Convert.ToDouble(velocidadei.Text);
                    a = Convert.ToDouble(aceleracao.Text);
                    t = Convert.ToDouble(tempo.Text);
                    //formula
                    aux = (v0 * t) + ((a * (t * t)) / 2);
                    if (aux <= 0)
                    {
                        r = s + aux;

                        formula = String.Format("S=S0+v0*t+a*t²/2\n" +
    "                    {0}=S0+{1}*{2}+{3}*{2}²/2\n" +
    "                    {0}=S0+{4}+{3}*{5}/2\n" +
    "                    {0}=S0+{4}+{6}/2\n" +
    "                    {0}=s0+{4}+{7}\n" +
    "                    {0}=s0+{8}\n" +
    "                    {0}+{8}=s0\n", s, v0, t, a, v0 * t, t * t, a * (t * t), (a * (t * t)) / 2, (v0 * t) + (a * (t * t)) / 2);
                    }

                    else
                    {
                        r = s - aux;
                    }
                    formula = String.Format("S=S0+v0*t+a*t²/2\n" +
                        "                    {0}=S0+{1}*{2}+{3}*{2}²/2\n" +
                        "                    {0}=S0+{4}+{3}*{5}/2\n" +
                        "                    {0}=S0+{4}+{6}/2\n" +
                        "                    {0}=s0+{4}+{7}\n" +
                        "                    {0}=s0+{8}\n" +
                        "                    {0}-{8}=s0\n", s, v0, t, a, v0 * t, t * t, a*(t*t), (a*(t*t))/2, (v0*t)+ (a * (t * t)) / 2);
                    formulai.Text = formula;
                    //resultado
                    result.Text = Convert.ToString(r);
                    break;
                //Delta S............................................................................
                case 6:
                    v = Convert.ToDouble(velocidade.Text);
                    v0 = Convert.ToDouble(velocidadei.Text);
                    a = Convert.ToDouble(aceleracao.Text);
                    //formula
                    aux = (v0*v0);
                    aux2 = 2 * a;
                    if (aux <= 0)
                    {
                        r = ((v*v) + aux)/aux2;

                        formula = String.Format("v²=v0²+2*a*Δs\n" +
                            "                   {0}²={1}²+2*{2}*Δs\n" +
                            "                   {3}={4}+{5}*Δs\n" +
                            "                   {3}+{4}={5}*Δs\n" +
                            "                   {6}/{5}=Δs\n", v, v0, a, (v*v), (v0*v0), (2*a), (v*v)-(v0*v0));
                    }

                    else
                    {
                        r = ((v * v) - aux) / aux2;
                    }
                    formula = String.Format("v²= v0²+2 * a * Δs\n" +
                            "                {0}²={1}²+2*{2}*Δs\n" +
                            "                {3}={4}+{5}*Δs\n" +
                            "                {3}-{4}={5}*Δs\n" +
                            "                {6}/{5}=Δs\n", v, v0, a, (v * v), (v0 * v0), (2 * a), (v * v) - (v0 * v0));
                    formulai.Text = formula;
                    //resultado
                    result.Text = Convert.ToString(r);
                    break;
                //Torricelli............................................................................
                case 7:
                    v0 = Convert.ToDouble(velocidadei.Text);
                    a = Convert.ToDouble(aceleracao.Text);
                    ds = Convert.ToDouble(deltas.Text);
                    //formula
                    aux = (v0 * v0) + (2 * a * ds);
                    r = Math.Sqrt(aux);

                    formula = String.Format("V²=v0²+2*a*Δs\n" +
                        "                   V²={0}²+2*{1}*{2}\n" +
                        "                   V²={3}+{4}\n" +
                        "                   V²={5}\n" +
                        "                   V=√{5}\n" +
                        "                   V={6}\n", v0, a, ds, (v0*v0), (2*a*ds), (v0*v0)+(2*a*ds), Math.Sqrt(aux));
                    formulai.Text = formula;
                    //resultado
                    result.Text = Convert.ToString(r);
                    break;
            }
        }


        private void formulai_Click(object sender, EventArgs e)
        {

        }

        private void formulai_Click_1(object sender, EventArgs e)
        {

        }
    }
}
