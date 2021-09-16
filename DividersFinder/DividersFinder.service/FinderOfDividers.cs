using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace DividersFinder.service
{
    public interface IDividersFinder
    {
       public List<ulong> FindNumbers(ulong number);
    }
    public class FinderOfDividers : IDividersFinder
    {
       
        public List<ulong> FindNumbers(ulong number)
        {
            
            var matchDictionaryResult = new Dictionary<ulong, List<ulong>>();
            ulong resultDividing;
            List<ulong> dividersList = new List<ulong>();
            
            for (ulong i = 1; i <= number; i++)
            {
                ulong checkModulo = number % i;
                if (checkModulo == 0)
                {
                    resultDividing = number / i;
                    dividersList.Add(resultDividing);
                }
            }

           // matchDictionaryResult.Add(number, dividersList);
            return dividersList;        
        }       
    }
}
