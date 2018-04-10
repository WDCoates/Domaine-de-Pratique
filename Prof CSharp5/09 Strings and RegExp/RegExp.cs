using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using Cons = System.Console;


namespace ConsoleA1._09_Strings_and_RegExp
{
    public struct RegExp
    {
        const string myTest = @"Take this kiss upon the brow!
And, in parting from you now,
Thus much let me avow--
You are not wrong, who deem
That my days have been a dream;
Yet if hope has flown away
In a night, or in a day,
In a vision, or in none,
Is it therefore the less gone?
All that we see or seem
Is but a dream within a dream.

I stand amid the roar
Of a surf-tormented shore,
And I hold within my hand
Grains of the golden sand--
How few! yet how they creep
Through my fingers to the deep,
While I weep--while I weep!
O God! can I not grasp
Them with a tighter clasp?
O God! can I not save
One from the pitiless wave?
Is all that we see or seem
But a dream within a dream?";


        

        public static void runReg (string pat)
        {
            MatchCollection matches = Regex.Matches(myTest, pat, RegexOptions.ExplicitCapture);

            foreach (Match m in matches)
            {
                Cons.WriteLine($"Match: {m} at {m.Index}");
            }


            Cons.WriteLine($"Breakup a url...");


            string sUrl = @"Is there a great url in here http://www.davecoates.co.uk and with a port? http://www.davecoates.co.uk:4444";
            
            pat = @"\b(\S+):\/\/([^: ]+)(?::(\S+))?\b";    //this does not quite work as a pattern but work in online tools!???
            
            matches = Regex.Matches(sUrl, pat);

            foreach (Match m in matches)
            {
                Cons.WriteLine($"Match: {m} at {m.Index}");


                foreach (var g in m.Groups)
                {
                    Cons.WriteLine($"Group in Match: {g}");
    
                }
                
            }

        }
    }
}
