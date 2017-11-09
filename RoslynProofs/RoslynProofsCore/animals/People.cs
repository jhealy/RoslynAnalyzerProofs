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

        // S2239
        public const string CHECKBOX_STRING = "<span class=\"span{7}\" style=\"{0}\"><input type=\"checkbox\" id=\"{7}\" name=\"{1}\" checked=\"{2}\"  tablename=\"{4}\" value=\"{5}\" tabindex=\"{6}\" />&nbsp;<label for=\"{7}\">{3}</label></span>";
        public const string CHECKBOX_UNCHECK_STRING = "<span class=\"span{6}\" style=\"{0}\"><input type=\"checkbox\" id=\"{6}\" name=\"{1}\" tablename=\"{3}\" value=\"{4}\" tabindex=\"{5}\" />&nbsp;<label for=\"{6}\">{2}</label></span>";
    }
}
