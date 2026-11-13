using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace DataTier
{
    public class AllStudents
    {
        public static List<Student> LoadFromFile(string path)
        {
            var list = new List<Student>();
            if (!File.Exists(path)) return list;

            foreach (var raw in File.ReadAllLines(path, Encoding.UTF8))
            {
                var line = raw.Trim();
                if (string.IsNullOrWhiteSpace(line)) continue;

                // убрать номер строки в начале: "1 Иванов..."
                if (char.IsDigit(line[0]))
                {
                    int sp = line.IndexOf(' ');
                    if (sp > 0) line = line.Substring(sp + 1).Trim();
                }

                // ФИО * группа * курс * задолженности
                string[] p = line.Split('*');
                if (p.Length < 4) continue;

                list.Add(new Student
                {
                    Fio = p[0].Trim(),
                    Group = p[1].Trim(),
                    Course = int.Parse(p[2].Trim()),
                    Debts = int.Parse(p[3].Trim())
                });
            }
            return list;
        }
    }
}