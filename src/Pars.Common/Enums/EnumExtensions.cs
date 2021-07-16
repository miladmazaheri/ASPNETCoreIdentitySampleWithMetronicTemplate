using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pars.Common.Enums
{
    public static class EnumExtensions
    {
        public static string GetName(this OrderStatus orderStatus)
        {
            switch (orderStatus)
            {
                case OrderStatus.New:
                    return "جدید";
                case OrderStatus.InProgress:
                    return "در حال تولید";
                case OrderStatus.Delivered:
                    return "تحویل شده";
                default:
                    return string.Empty;
            }
        }

        public static string GetName(this OrderStatus? orderStatus)
        {
            if (!orderStatus.HasValue) return string.Empty;
            return orderStatus.Value.GetName();
        }
    }
}
