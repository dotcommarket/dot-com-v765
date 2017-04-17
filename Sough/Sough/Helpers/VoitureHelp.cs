using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sough.Models;
namespace Sough.Helpers
{
    public class VoitureHelp
    {
        private int cpt_color = 0;
        private int cpt_car_shape = 0;
        public  static string last_query = "select * from Voitures";
        public static List<Voiture> lastResult = new List<Voiture>();

        public VoitureHelp()
        {

        }

        public int GetCptColor() { return cpt_color; }
        public int GetCptShape() { return cpt_car_shape; }
        public string GetQueryColor(string color1 = "", string color2 = "", string color3 = "", string color4 = "", string color5 = "", string color6 = "", string color7 = "", string color8 = "")
        {
            string query_color = "";
            //int cpt_color = 0;

            if (color1.Length > 0)
            {
                if (query_color.Length > 1)
                    query_color += " OR color = '" + color1 + "'";
                else
                    query_color += "color = '" + color1 + "'";
                cpt_color++;
            }
            if (color2.Length > 0)
            {
                if (query_color.Length > 1)
                    query_color += " OR color = '" + color2 + "'";
                else
                    query_color += "color = '" + color2 + "'";
                cpt_color++;
            }
            if (color3.Length > 0)
            {
                if (query_color.Length > 1)
                    query_color += " OR color = '" + color3 + "'";
                else
                    query_color += "color = '" + color3 + "'";
                cpt_color++;
            }
            if (color4.Length > 0)
            {
                if (query_color.Length > 1)
                    query_color += " OR color = '" + color4 + "'";
                else
                    query_color += "color = '" + color4 + "'";
                cpt_color++;
            }
            if (color5.Length > 0)
            {
                if (query_color.Length > 1)
                    query_color += " OR color = '" + color5 + "'";
                else
                    query_color += "color = '" + color5 + "'";
                cpt_color++;
            }
            if (color6.Length > 0)
            {
                if (query_color.Length > 1)
                    query_color += " OR color = '" + color6 + "'";
                else
                    query_color += "color = '" + color6 + "'";
                cpt_color++;
            }
            if (color7.Length > 0)
            {
                if (query_color.Length > 1)
                    query_color += " OR color = '" + color7 + "'";
                else
                    query_color += "color = '" + color7 + "'";
                cpt_color++;
            }
            if (color8.Length > 0)
            {
                if (query_color.Length > 1)
                    query_color += " OR color = '" + color8 + "'";
                else
                    query_color += "color = '" + color8 + "'";
                cpt_color++;
            }

            if (query_color.Contains("OR"))
                query_color = String.Format("({0})", query_color);

            return query_color;
        }
        public string GetQueryShape(string car_shape1 = "", string car_shape2 = "", string car_shape3 = "", string car_shape4 = "")
        {
            string query_shape = "";
            

            if (car_shape1.Length > 0)
            {
                if (query_shape.Length > 1)
                    query_shape += " OR car_shape = '" + car_shape1 + "'";
                else
                    query_shape += "car_shape = '" + car_shape1 + "'";
                cpt_car_shape++;
            }
            if (car_shape2.Length > 0)
            {
                if (query_shape.Length > 1)
                    query_shape += " OR car_shape = '" + car_shape2 + "'";
                else
                    query_shape += "car_shape = '" + car_shape2 + "'";
                cpt_car_shape++;
                //f_car_shape.Add(2);
            }
            if (car_shape3.Length > 0)
            {
                if (query_shape.Length > 1)
                    query_shape += " OR car_shape = '" + car_shape3 + "'";
                else
                    query_shape += "car_shape = '" + car_shape3 + "'";
                cpt_car_shape++;
                //f_car_shape.Add(3);
            }
            if (car_shape4.Length > 0)
            {
                if (query_shape.Length > 1)
                    query_shape += " OR car_shape = '" + car_shape4 + "'";
                else
                    query_shape += "car_shape = '" + car_shape4 + "'";
                cpt_car_shape++;
                //f_car_shape.Add(4);
            }

            if (query_shape.Contains("OR"))
                query_shape = String.Format("({0})", query_shape); // AJouter les parethese s'il y a plusieurs choix

            return query_shape;
        }

        public string GetQueryModele(string m_audi = "", string m_bmw = "", string m_mercedes = "", string m_nissan = "", string m_reault = "", string m_toyota = "")
        {
            string modele=null;
            if (m_audi.Length > 0 && !m_audi.Equals("")) modele = m_audi;
            if (m_bmw.Length > 0 && !m_bmw.Equals("")) modele = m_bmw;
            if (m_mercedes.Length > 0 && !m_mercedes.Equals("")) modele = m_mercedes;
            if (m_nissan.Length > 0 && !m_nissan.Equals("")) modele = m_nissan;
            if (m_reault.Length > 0 && !m_reault.Equals("")) modele = m_reault;
            if (m_toyota.Length > 0 && !m_toyota.Equals("")) modele = m_toyota;


            return modele;
        }
    }
}