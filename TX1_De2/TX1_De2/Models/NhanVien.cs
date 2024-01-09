using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace TX1_De2.Models
{
    public class NhanVien
    {
        public string manv { get; set; }
        public string hoten  { get; set; }
        public string gioitinh { get; set; }
        public string diachi { get; set; }
        public int songaylam { get; set; }
        public float luongngay { get; set; }
        public float tienluong
        {
            get { return songaylam *luongngay; }
        }
        public NhanVien()
        {

        }
        public NhanVien(string manv, string hoten, string gioitinh, string diachi, int songaylam, float luongngay)
        {
            this.manv = manv;
            this.hoten = hoten;
            this.gioitinh = gioitinh;
            this.diachi = diachi;
            this.songaylam = songaylam;
            this.luongngay = luongngay;
        }
    }
}