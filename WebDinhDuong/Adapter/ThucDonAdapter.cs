using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebDinhDuong.Models;

namespace WebDinhDuong.Adapter
{
    public class ThucDonAdapter :IThucDon   //thông dịch viên
    {
        private ThucDonAdaptee adaptee;
        public ThucDonAdapter(ThucDonAdaptee adaptee)
        {
            this.adaptee = adaptee;
        }
        //Tiến hành thông dịch
        public void send(ThucDon thucdon)
        {
            thucdon.Calo = (double)thucdon.Calo / thucdon.SoLuong;
            thucdon.Carb = (double)thucdon.Carb / thucdon.SoLuong;
            thucdon.Protein = (double)thucdon.Protein / thucdon.SoLuong;
            thucdon.Fat = (double)thucdon.Fat / thucdon.SoLuong;
            adaptee.receive(thucdon);

        }
    }
}