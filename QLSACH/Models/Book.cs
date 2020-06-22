using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace QLSACH.Models
{
    public class Book
    {
        private int id;
        private string title;
        private string author;
        private string img_cover;
        public Book()
        {

        }
        public Book(int id, string title, string author, string img_cover)
        {
            this.id = id;
            this.title = title;
            this.author = author;
            this.img_cover = img_cover;
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        [Required (ErrorMessage ="Tieu de khong duoc trong ")]
        [StringLength(250,ErrorMessage ="Tieu de sach khong duoc qua 250 ki tu")]
        [Display(Name="Tieu de")]
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        public string Imgcover
        {
            get { return img_cover; }
            set { img_cover = value; }
        }
    }   
}