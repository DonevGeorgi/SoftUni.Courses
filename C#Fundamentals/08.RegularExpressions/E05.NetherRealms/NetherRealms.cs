using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace P05.NetherRealms
{
    internal class NetherRealms
    {
        static void Main()
        {
            Dictionary<string, List<double>> demonParticipants
                = new Dictionary<string, List<double>>();

            string paternForHealth = @"[^\+\-\*\/\.\d]";
            string paternForDamage = @"(?<digit>[\-\+]?\d+(\.\d+)?)";
            string paternForSighs = @"[\*\/]";
            Regex healthRegex = new Regex(paternForHealth);
            Regex damageRegex = new Regex(paternForDamage);
            Regex sighRegex = new Regex(paternForSighs);

            string[] input = Regex.Split(Console.ReadLine(), @" *,{1} *");

            for (int i = 0; i < input.Length; i++)
            {
                string realName = input[i];

                MatchCollection demonsHealthChar = healthRegex.Matches(input[i]);
                string demonNameInLetters = string.Empty;

                foreach (Match letter in demonsHealthChar)
                {
                    demonNameInLetters += letter.Value.ToString();
                }

                double demonsHealth = HealthCalculation(demonNameInLetters);
                double demonDamage = DamageCalculation(damageRegex, sighRegex, input, i);

                DemonInitializing(demonParticipants, realName, demonsHealth, demonDamage);
            }

            foreach (var demons in demonParticipants.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{demons.Key} - {demons.Value[0]} health, {demons.Value[1]:f2} damage");
            }
        }

        private static void DemonInitializing(Dictionary<string, List<double>> demonParticipants, string demonName, double demonsHealth, double demonDamage)
        {
            if (!demonParticipants.ContainsKey(demonName))
            {
                demonParticipants[demonName] = new List<double>();
            }

            demonParticipants[demonName].Add(demonsHealth);
            demonParticipants[demonName].Add(demonDamage);
        }

        static double HealthCalculation(string demonName)
        {

            double demonHealth = 0;

            foreach (char letter in demonName)
            {
                demonHealth += (double)letter;
            }

            return demonHealth;
        }
        static double DamageCalculation(Regex damageRegex, Regex sighRegex, string[] input, int i)
        {
            MatchCollection demonsDamageChar = damageRegex.Matches(input[i]);
            MatchCollection sighs = sighRegex.Matches(input[i]);

            double demonsDamage = 0;

            foreach (Match digit in demonsDamageChar)
            {
                demonsDamage += double.Parse(digit.Value);
            }

            foreach (Match sigh in sighs)
            {
                if (sigh.Value == "*")
                {
                    demonsDamage *= 2;
                }
                else
                {
                    demonsDamage /= 2;
                }
            }

            return demonsDamage;
        }
    }
}
