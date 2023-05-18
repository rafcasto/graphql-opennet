using GraphqlDomain.Contract;
using GraphqlDomain.Models.Domain.IRD;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphqlBusiness.Repository
{
    public class IRDRepository : IIRDRepository
    {
        public List<IRDResponse> GenerateTaxNumbers(IRDRequest request)
        {
            return generateNumbers(request.Total, request.Seed.ToString());
        }

        private List<IRDResponse> generateNumbers(long target, string seed)

        {
            if (string.IsNullOrEmpty(seed))
            {
                throw new Exception("seed is null or empty enter a valid IRD number ");

            }

            if (Strings.Len(seed) < 8 || Strings.Len(seed) > 9)
            {
                throw new Exception("Invalid IRD seed, IRD seed lenght should 8 or 9 characters long");

            }
            if (Strings.Len(seed) == 8)

            {
                seed = "0" + seed;
            }
            return getIrdNumbers(target, seed);
        }



        private List<IRDResponse> getIrdNumbers(long target, string seed)

        {

            List<IRDResponse> irdList = new List<IRDResponse>();

            long counter = 0L;

            long tmpSeed;

            while (counter != target)

            {
                // seed = Str(Val(seed) + 1)

                tmpSeed = long.Parse(seed);

                tmpSeed = tmpSeed + 1L;

                seed = tmpSeed.ToString();



                if (Double.Parse(seed) == 999999999d)

                {

                    // ActiveSheet.Cells(counter + 1L, 1).Value = "End of IRD Number Range";

                    throw new Exception("end of IRD number range");

                }



                if (checkIRDnum(seed))

                {

                    counter = counter + 1L;



                    irdList.Add(

                      new IRDResponse()
                      {

                          IRDNumber = seed

                      }

                    );

                }

            }

            return irdList;

        }



        private bool checkIRDnum(string IRDnum)

        {

            bool checkIRDnumRet = default;

            long tmpIRDnum;

            tmpIRDnum = (long)Math.Round(Conversion.Val(IRDnum));

            if (Strings.Len(IRDnum) != 9 & Strings.Len(IRDnum) != 8)

            {

                checkIRDnumRet = false;

            }

            else if (Mod11Check(tmpIRDnum))

            {

                if (tmpIRDnum == 10000017L | tmpIRDnum == 999999999L)

                {

                    checkIRDnumRet = false;

                }

                else

                {

                    checkIRDnumRet = true;

                }

            }

            else

            {

                checkIRDnumRet = false;

            }



            return checkIRDnumRet;

        }





        private bool Mod11Check(long IRDnum)

        {

            bool Mod11CheckRet = default;

            long IRDnum1;

            long IRDnum2;

            long IRDnum3;

            long IRDnum4;

            long IRDnum5;

            long IRDnum6;

            long IRDnum7;

            long IRDnum8;

            long IRDchk;

            long IRD1;

            long IRD2;

            long IRD3;

            long IRD4;

            long IRD5;

            long IRD6;

            long IRD7;

            long IRD8;

            long Working1;

            long Mod1;

            long Working2;

            long Mod2;

            IRDnum1 = (long)Math.Round(Conversion.Int(IRDnum / 100000000d));

            IRDnum2 = (long)Math.Round(Conversion.Int(IRDnum / 10000000d));

            IRDnum3 = (long)Math.Round(Conversion.Int(IRDnum / 1000000d));

            IRDnum4 = (long)Math.Round(Conversion.Int(IRDnum / 100000d));

            IRDnum5 = (long)Math.Round(Conversion.Int(IRDnum / 10000d));

            IRDnum6 = (long)Math.Round(Conversion.Int(IRDnum / 1000d));

            IRDnum7 = (long)Math.Round(Conversion.Int(IRDnum / 100d));

            IRDnum8 = (long)Math.Round(Conversion.Int(IRDnum / 10d));

            IRDchk = IRDnum - IRDnum8 * 10L;

            IRD8 = IRDnum8 - IRDnum7 * 10L;

            IRD7 = IRDnum7 - IRDnum6 * 10L;

            IRD6 = IRDnum6 - IRDnum5 * 10L;

            IRD5 = IRDnum5 - IRDnum4 * 10L;

            IRD4 = IRDnum4 - IRDnum3 * 10L;

            IRD3 = IRDnum3 - IRDnum2 * 10L;

            IRD2 = IRDnum2 - IRDnum1 * 10L;

            IRD1 = IRDnum1;

            Working1 = 3L * IRD1 + 2L * IRD2 + 7L * IRD3 + 6L * IRD4 + 5L * IRD5 + 4L * IRD6 + 3L * IRD7 + 2L * IRD8;

            Mod1 = Working1 % 11L;

            if (Mod1 == 1L)

            {

                Working2 = 7L * IRD1 + 4L * IRD2 + 3L * IRD3 + 2L * IRD4 + 5L * IRD5 + 2L * IRD6 + 7L * IRD7 + 6L * IRD8;

                Mod2 = Working2 % 11L;

                if (Mod2 == 1L)

                {

                    Mod11CheckRet = false;

                }

                else if (Mod2 == 0L)

                {

                    if (IRDchk == Mod2)

                    {

                        Mod11CheckRet = true;

                    }

                    else

                    {

                        Mod11CheckRet = false;

                    }

                }

                else if (IRDchk == 11L - Mod2)

                {

                    Mod11CheckRet = true;

                }

                else

                {

                    Mod11CheckRet = false;

                }

            }

            else if (Mod1 == 0L)

            {

                if (IRDchk == Mod1)

                {

                    Mod11CheckRet = true;

                }

                else

                {

                    Mod11CheckRet = false;

                }

            }

            else if (IRDchk == 11L - Mod1)

            {

                Mod11CheckRet = true;

            }

            else

            {

                Mod11CheckRet = false;

            }



            return Mod11CheckRet;

        }
    }
}
