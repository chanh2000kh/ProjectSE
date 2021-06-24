using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDinhDuong.Factory
{
    public class PeopleFactory
    {
        public IPeopleStatus getPeopleStatus(double bmi)
        {
            IPeopleStatus value = null;
            if(bmi<18.5)
            {
                value = new NguoiThieuCan();
            }
            else if(bmi>=18.5 && bmi<24.9)
            {
                value = new NguoiBinhThuong();
            }  
            else
            {
                value = new NguoiThuaCan();
            }
            return value;
        }
    }
}