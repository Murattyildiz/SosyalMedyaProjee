using Core.Utulities.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utulities.Business
{
    public class BusinessRules
    {
        public static IResult? Run(params IResult[] results)
        {
            foreach (var result in results)
            {
                if (!result.Success)
                {
                    return result;
                }
            }
            return null;
        }
    }
}
