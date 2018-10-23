using System;

using Cons = System.Console;

namespace ConsoleA1._14_Memory_and_Pointers
{
    class Scope1
    {
        public void level1()
        {

            SelfDestructor sd = null;
            
            try
            {
                sd = new SelfDestructor();    
                sd.Up();
                
            }
            catch (Exception e)
            {
                Cons.WriteLine(e.Message);
            }
            finally
            {
                if (sd != null)
                {
                    sd.Dispose();
                }
            }

            //Ensures Dispose is used on closing, },  brace.
            using (SelfDestructor sd2 = new SelfDestructor())
            {
                sd2.Up();
            }

        }
    }
}
