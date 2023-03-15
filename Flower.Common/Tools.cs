using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdFlower.Common
{
    public class Tools
    {
        /// <summary>
        /// 生成验证码的字符串
        /// </summary>
        /// <param name="length">要生成字符串长度</param>
        /// <returns></returns>
        public static string CreateValidateString()
        {

            //准备一组供验证码展示的数据
            string chars = "abcdefghijklmnopqrstuvwxyz";
            Random r = new(DateTime.Now.Millisecond);
            string validateString = "";
            int length = 4;
            for (int i = 0; i < length; i++)
            {
                validateString += chars[r.Next(chars.Length)];
            }
            return validateString;
        }

      
           
        }
    }

