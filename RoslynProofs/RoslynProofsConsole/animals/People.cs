using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoslynProofsConsole.animals
{
    public class People
    {
        // SPOT THE PROBLEM: S2933
        string RequiredFieldErrorMessage = @"This field is required.";
        string DateFieldErrorMessage = @"This is not a valid date.";

        string FirstName { get; set; }
        string LastName { get; set; }
        string TargetValue { get; set; }

        // S2219 - omg
        public void CheckTargetType()
        {
            string targetValue = (this.TargetValue ?? "").ToString();
            if ( targetValue.GetType() == typeof(bool))
            {
                targetValue = targetValue.ToLower();
            }
        }
    }
}
