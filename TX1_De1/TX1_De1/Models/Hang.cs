using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace TX1_De1.Models
{
    public class Hang
    {
        public string maHang { get; set; }  
        public string tenHang { get; set; }
        public string loaiHang  { get; set; }
        public float donGia { get; set; }
        public float soLuong { get; set; }
        public float thanhTien
        {
            get
            {
                if (soLuong >= 100)
                {
                    return donGia * soLuong * 0.9f;
                }
                else
                {
                    return donGia * soLuong;
                }
            }
        }
        public Hang()
        {

        }
        public Hang(string maHang, string tenHang, string loaiHang, float donGia, float soLuong)
        {
            this.maHang = maHang;
            this.tenHang = tenHang;
            this.loaiHang = loaiHang;
            this.donGia = donGia;
            this.soLuong = soLuong;
        }
    }
}