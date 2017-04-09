using Sough.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Sough.Helpers
{
    public class TraitementDonnees
    {

        public string GetShowWare(Ware ware)
        {
            string src = "";

            if (ware.model_name.Equals("Voitures"))
            {
                src = "../Voiture/ShowWare?id=" + ware.Id;
            }
            else if (ware.model_name.Equals("Vetements"))
            {
                src = "../Vetement/ShowWare?id=" + ware.Id;
            }


            return src;
        }


        public bool StringIsValid(string s)
        {
            return ((s != null) && (s.Length > 1));
        }

        public bool NumberIsValid(long n)
        {
            return ((n != null) && (n >= 0));
        } 

        public string GetAdsView(string cat)
        {
            string view = cat;
            view = view.TrimEnd('s');

            return view;

        }

        public string splitStrSM(string param) // param md,sm,xs
        {
            string finalstr = "";
            string[] split = param.Split(new Char[] { ',' });

            foreach (string s in split)
            {
                if (s.Trim() != "" && s.Trim().Length > 0)
                {
                    finalstr = s;
                    break;
                }
            }

            return finalstr;
        }

        public string NullToString(object Value)
        {
            return Value == null ? "" : Value.ToString();
        }

        public void Prixmm(ref ArrayList fields,string pmin,string pmax)
        {
            try {
                
                long prix_min = 0, prix_max = 0;
                if (pmin.Length > 0)
                {
                    prix_min = Int64.Parse(pmin);
                }

                if (pmax.Length > 0)
                {
                    prix_max = Int64.Parse(pmax);
                }
                
                if (prix_max != 0 && prix_min != 0)
                {
                    if (prix_min < prix_max)
                    {
                        fields.Add("prix >= " + prix_min);
                        fields.Add(prix_max + " >= prix");
                    }
                    else     // Si le prix max et le prix min sont inversé ou égaux
                    {
                        fields.Add("prix >= " + prix_max);
                        fields.Add(prix_min + " >= prix");
                    }
                }
                else if (prix_max != 0)
                {
                    fields.Add(prix_max + " >= prix");
                }
                else if(prix_min != 0)
                {
                    fields.Add("prix >= " + prix_min);
                }
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }

        public void Tmd5<T>(string p,ref T w) where T : Ware
        {
            byte[] asciiBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(p);
            byte[] hashedBytes = System.Security.Cryptography.MD5CryptoServiceProvider.Create().ComputeHash(asciiBytes);
            string hashedString = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();

            w.password = hashedString;
        }

        public string GetMd5(string p)
        {
            byte[] asciiBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(p);
            byte[] hashedBytes = System.Security.Cryptography.MD5CryptoServiceProvider.Create().ComputeHash(asciiBytes);
            string hashedString = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            return hashedString;
        }
        
        /* Save Date in model */
        public void SaveDate<T>(ref T w) where T : Ware
        {
            DateTime dt = DateTime.Now;
            w.temps = dt;
        }

        public string FormaterPrix(long prix)
        {
            string _prix = prix.ToString();

            try {
                var prix_formater = prix.ToString("N0", System.Globalization.CultureInfo.GetCultureInfo("fr"));
                return prix_formater;
            }
            catch(Exception e){
                return _prix;
            }
            
        }
    }
}