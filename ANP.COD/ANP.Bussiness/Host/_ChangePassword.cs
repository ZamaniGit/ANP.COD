using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ANP.Data;
using ANP.Common;
using System.Data;
using ANP.Bussiness.Models;
using ANP.Data.Object;
using ANP.Bussiness.Objects;

namespace ANP.Bussiness.Host
{
    public class _ChangePassword
    {
        IChangePassword _host;
        LoginDetails UserInfo;
        UserData Udata = new UserData();

        public void Init(IChangePassword host, LoginDetails UserDetail)
        {
            _host = host;
            UserInfo = UserDetail;
        }

        public bool IsExist()
        {
            DataTable cnt = new DataTable();
            cnt = Udata.ReturnUserInfoByUserIdAndPass(_host.txt_curentpass.Text.Trim(), UserInfo.PostNodeCode, UserInfo.UserName, UserInfo.RoleID,UserInfo.StateCode);

            if (cnt.Rows.Count > 0)
                return true;
            else
            {
                _host.hf_msg.Value = "رمز فعلی وارد شده در بانک اطلاعاتی موجود نمی باشد";
                return false;
            }
        }

        public bool ChgPassword()
        {
            bool Result = false;
            try
            {
                if (string.Compare(_host.txt_newpass.Text.Trim(), _host.txt_new_repass.Text.Trim()) == 0)
                {
                    if(UserInfo.PostNodeCode==0)
                        Result=Udata.UpdatePassByState(_host.txt_newpass.Text.Trim(),UserInfo.UserName,UserInfo.PostNodeCode,UserInfo.RoleID);
                    else
                        Result=Udata.UpdatePassByPostNode(_host.txt_newpass.Text.Trim(),UserInfo.UserName,UserInfo.PostNodeCode);


                    if (Result == true)
                        _host.hf_msg.Value = "رمز ورود جدید ذخیره شد";
                    else
                        _host.hf_msg.Value = "رمز جدید قابل ثبت شدن نمی باشد.";
                }
                else
                {
                    _host.hf_msg.Value = "رمز جدید وارد شده با تکرار آن برابر نمی باشد.";
                }
                return Result;
            }
            catch { _host.hf_msg.Value = "خطا در ذخیره اطلاعات"; return false; }
        }
    }
}
