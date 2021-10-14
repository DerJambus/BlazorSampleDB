using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSampleDB.Client.Pages
{
    public partial class Counter
    {

        private int currentCount = 0;
        private ElementReference elemRef;
        private void IncrementCount()
        {
            currentCount++;
        }


        

        public void Focus()
        {
            elemRef.FocusAsync();
        }
    }
}
