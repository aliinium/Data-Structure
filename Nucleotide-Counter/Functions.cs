using System;
using System.Linq;

namespace Nucleotide Counter
{
    public class Functions
    {
        #region -- Check_Codon --
        public char CheckCodon(string s)
        {
            switch (s)
            {
                case "GCA":
                case "GCC":
                case "GCG":
                case "GCT":
                    return 'A';

                case "AGA":
                case "AGG":
                case "CGA":
                case "CGC":
                case "CGG":
                case "CGT":
                    return 'R';

                case "AAC":
                case "AAT":
                    return 'N';

                case "GAC":
                case "GAT":
                    return 'D';

                case "TGC":
                case "TGT":
                    return 'C';

                case "CAA":
                case "CAG":
                    return 'Q';

                case "GAA":
                case "GAG":
                    return 'E';

                case "GGA":
                case "GGC":
                case "GGG":
                case "GGT":
                    return 'G';

                case "CAC":
                case "CAT":
                    return 'H';

                case "ATA":
                case "ATC":
                case "ATT":
                    return 'I';

                case "TTA":
                case "TTG":
                case "CTA":
                case "CTC":
                case "CTG":
                case "CTT":
                    return 'L';

                case "AAA":
                case "AAG":
                    return 'K';

                case "ATG":
                    return 'M';

                case "TTC":
                case "TTT":
                    return 'F';

                case "CCA":
                case "CCC":
                case "CCG":
                case "CCT":
                    return 'P';

                case "AGC":
                case "AGT":
                case "TCA":
                case "TCC":
                case "TCG":
                case "TCT":
                    return 'S';

                case "ACA":
                case "ACC":
                case "ACG":
                case "ACT":
                    return 'T';

                case "TGG":
                    return 'W';

                case "TAC":
                case "TAT":
                    return 'Y';

                case "GTA":
                case "GTC":
                case "GTG":
                case "GTT":
                    return 'V';

                default:
                    return '*';
            }
        }
        #endregion

        #region -- Manual --
        public void Manual()
        {
            string DNAstr;

            Console.Write("Enter DNA String: \t");
            DNAstr = Console.ReadLine();

            Procces(DNAstr);

            Console.Write("\n\nTap Enter To Go To The Menu.");

            Console.ReadKey();

            Menu();

            
        }
        #endregion

        #region -- Procces --
        public void Procces(string DNAstr)
        {
            DNAstr = DNAstr.ToUpper();

            Console.Clear();

            Console.Write("DNA String: \t" + DNAstr + "\n\n");

            int[,] dna = new int[2, 4];

            try
            {
                dna[0, 0] = DNAstr.Count(c => c == 'A');
                dna[0, 1] = DNAstr.Count(c => c == 'C');
                dna[0, 2] = DNAstr.Count(c => c == 'G');
                dna[0, 3] = DNAstr.Count(c => c == 'T');

                dna[1, 0] = ((dna[0, 0] * 100) / DNAstr.Length);
                dna[1, 1] = ((dna[0, 1] * 100) / DNAstr.Length);
                dna[1, 2] = ((dna[0, 2] * 100) / DNAstr.Length);
                dna[1, 3] = ((dna[0, 3] * 100) / DNAstr.Length);
            }
            catch { }

            Console.Write("\t|\tA \t\tC \t\tG \t\tT \n");
            Console.Write("--------|---------------------------------------------------------------\n");
            Console.Write("Count   |\t" + dna[0, 0] + "\t\t" + dna[0, 1] + "\t\t" + dna[0, 2] + "\t\t" + dna[0, 3] + "\n");
            Console.Write("Percent |\t" + dna[1, 0] + "%\t\t" + dna[1, 1] + "%\t\t" + dna[1, 2] + "%\t\t" + dna[1, 3] + "%\n\n");

            string[,] dnaa = new string[DNAstr.Length / 3, DNAstr.Length / 3];

            for (int i = 0; i < DNAstr.Length; i++)
            {
                try
                {
                    dnaa[0, i] = DNAstr.Substring(0, 3);
                    dnaa[1, i] = CheckCodon(dnaa[0, i]).ToString();
                    DNAstr = DNAstr.Remove(0, 3);
                }
                catch { }
            }

            Console.Write("\n");

            try
            {
                for (int i = 0; i < DNAstr.Length; i++)
                    Console.Write(dnaa[0, i] + " , ");
                Console.Write("\n");
                for (int i = 0; i < DNAstr.Length; i++)
                    Console.Write(" " + dnaa[1, i] + "  , ");

                int start = 0, end = 0;
                for (int i = 0; i < DNAstr.Length; i++)
                {
                    if (dnaa[1, i] == "M")
                        start = (i * 3) + 1;
                    if (dnaa[1, i] == "*")
                        end = (i * 3) + 1;
                }

                Console.WriteLine("\n\nStart Codon = " + start.ToString() + "\t End Codon = " + end.ToString());
            }
            catch { }
        }
        #endregion 

        #region -- File --
        public void File()
        {
            string DNAstr = "", filename;

            Console.Write("Please Place The File Next To The .exe File And Enter The File Name. (E.g. DNAFile.txt) \n\t -> ");
            filename = Console.ReadLine();

            try
            {
                DNAstr = System.IO.File.ReadAllText(filename);
            } catch { }

            Procces(DNAstr);

            Console.Write("\n\nTap Enter To Go To The Menu.");

            Console.ReadKey();

            Menu();
        }
        #endregion

        #region -- Menu --
        public bool Menu()
        {
            Console.Clear();

            char r = 'x';

            Console.Write("\n\n");
            Console.WriteLine("\t\t 1. Enter Manually DNA String.");
            Console.WriteLine("\t\t 2. Enter DNA String With File.");
            Console.WriteLine("\t\t 0. Exit.");

            Console.Write("\n\t\t -> ");

            try
            {
                r = char.Parse(Console.ReadLine());
            } catch { }


            if (r == '1')
            {
                Console.Clear();
                Manual();
            }
            else if (r == '2')
            {
                Console.Clear();
                File();
            }
            else if (r == '0')
                Environment.Exit(0);
            else
                Menu();

            return false;
        }
        #endregion
    }
}
