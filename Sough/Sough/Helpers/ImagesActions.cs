using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Drawing;
using Sough.Models;
using System.Web.Helpers;


using System.Data;
using System.Data.Entity;
using System.Drawing.Imaging;
using System.Data.SqlClient;
using System.Collections;
using System.Data.Entity.Validation;
using PagedList;
using System.Security.Cryptography;


namespace Sough.Helpers
{
    public class ImagesActions
    {

        public byte[] imagebytes { set; get; }
        public string image_data = null;

        public static void ImagesModel<T>(ref T t, ref string image1, ref string image2,
                    ref string image3, ref string image4, ref IEnumerable<HttpPostedFileBase> files)
        where T : Ware
        {
            if (image1.Length > 100 && image2.Length > 100 && image3.Length > 100 && image4.Length > 100)
            {
                try
                {
                    System.Diagnostics.Debug.WriteLine("image.length > 100");
                    System.Diagnostics.Debug.WriteLine("img1 : " + image1);

                    byte[] img1 = Convert.FromBase64String(image1);
                    byte[] img2 = Convert.FromBase64String(image2);
                    byte[] img3 = Convert.FromBase64String(image3);
                    byte[] img4 = Convert.FromBase64String(image4);

                    WebImage img;
                    img = new WebImage(img1);
                    if (img.Width > 800 || img.Height > 800)
                    {
                        img.Resize(736, 552);
                        t.image1 = img.GetBytes();
                    }
                    else
                    {
                        t.image1 = img1;
                    }
                    img = new WebImage(img2);
                    if (img.Width > 800 || img.Height > 800)
                    {
                        img.Resize(736, 552);
                        t.image2 = img.GetBytes();
                    }
                    else
                    {
                        t.image2 = img2;
                    }

                    img = new WebImage(img3);
                    if (img.Width > 800 || img.Height > 800)
                    {
                        img.Resize(736, 552);
                        t.image3 = img.GetBytes();
                    }
                    else
                    {
                        t.image3 = img3;
                    }
                    img = new WebImage(img4);
                    if (img.Width > 800 || img.Height > 800)
                    {
                        img.Resize(736, 552);
                        t.image4 = img.GetBytes();
                    }
                    else
                    {
                        t.image4 = img4;
                    }

                    t.img_count = 4;
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("Exception in images : " + e.Data);
                }
            }
            else if (files != null) //files[i].contentLength > 0
            {
                List<HttpPostedFileBase> images = files.ToList();
                //int num_img = 0;

                if (images[0] != null)
                {
                    try
                    {
                        System.Diagnostics.Debug.WriteLine("http posted file base!!");
                        WebImage wimg;
                        wimg = new WebImage(images[0].InputStream);
                        if (wimg.Width > 800 || wimg.Height > 800)
                            wimg.Resize(736, 552); //maxWidth = 736,  maxHeight = 552

                        t.image1 = wimg.GetBytes();

                        wimg = new WebImage(images[1].InputStream);
                        if (wimg.Width > 800 || wimg.Height > 800)
                            wimg.Resize(736, 552); //maxWidth = 736,  maxHeight = 552

                        t.image2 = wimg.GetBytes();

                        wimg = new WebImage(images[2].InputStream);
                        if (wimg.Width > 800 || wimg.Height > 800)
                            wimg.Resize(736, 552); //maxWidth = 736,  maxHeight = 552

                        t.image3 = wimg.GetBytes();

                        wimg = new WebImage(images[3].InputStream);
                        if (wimg.Width > 800 || wimg.Height > 800)
                            wimg.Resize(736, 552); //maxWidth = 736,  maxHeight = 552

                        t.image4 = wimg.GetBytes();

                        t.img_count = 4;
                    }
                    catch (Exception e)
                    {
                        System.Diagnostics.Debug.WriteLine("Exception in images : " + e.Data);
                    }
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Exception in images");
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Exception in images");
            }

        }

        public string getDataImage(HttpPostedFileBase file)
        {
            string image_data_string = null;
            if (file != null)
            {
                image_data_string = "no_null";
                if (file.ContentLength > 0)
                {
                    //get the file's name
                    string theFileName = Path.GetFileName(file.FileName);

                    //get the bytes from the content stream of the file
                    byte[] thePictureAsBytes = new byte[file.ContentLength];
                    using (BinaryReader theReader = new BinaryReader(file.InputStream))
                    {
                        thePictureAsBytes = theReader.ReadBytes(file.ContentLength);
                    }

                    image_data_string = Convert.ToBase64String(thePictureAsBytes);
                    return image_data_string;
                }
                //return image_data_string;
            }
            
            return image_data_string;
        }
       
        
    }
}