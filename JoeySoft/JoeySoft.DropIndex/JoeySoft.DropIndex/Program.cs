using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JoeySoft.DropIndex
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePaths = Directory.GetFiles("IndexSql");

            string textTemplateSqlText = File.ReadAllText("TextTemplate.txt");

            string DeleteIndexDirectory = "DeleteIndexSql";

            //如果目录不存在 创建
            if (!Directory.Exists(DeleteIndexDirectory))
            {
                Directory.CreateDirectory(DeleteIndexDirectory);
            }

            foreach (var filePath in filePaths)
            {
                List<string> createSqlTexts = new List<string>();
                var fileName = Path.GetFileNameWithoutExtension(filePath);
                //读取文件
                string sqlText = File.ReadAllText(filePath, Encoding.GetEncoding("GB2312"));
                string[] sqlIndexs = sqlText.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                //匹配索引
                string regexIndexText = @"CREATE [a-zA-Z]+ INDEX ([1-9a-zA-Z_]+)";
                //匹配表
                string regexTableText = @"ON ([1-9a-zA-Z_\[.\]]+) \(";
                //匹配说明
                string regexRemarkText = @"--(.*)";
                string indexName = "", remark = "";
                foreach (var sqlIndex in sqlIndexs)
                {
                    var math2 = Regex.Matches(sqlIndex, regexRemarkText, RegexOptions.IgnoreCase);
                    if (math2.Count > 0)
                    {
                        if (math2[0].Groups.Count > 1)
                        {
                            remark = math2[0].Groups[1].Value;
                            continue;
                        }
                    }

                    var match = Regex.Matches(sqlIndex, regexIndexText, RegexOptions.IgnoreCase);
                    if (match.Count > 0)
                    {
                        if (match[0].Groups.Count > 1)
                        {
                            indexName = match[0].Groups[1].Value;
                            continue;
                        }
                    }
                    var match1 = Regex.Matches(sqlIndex, regexTableText, RegexOptions.IgnoreCase);
                    if (match1.Count > 0)
                    {
                        if (match1[0].Groups.Count > 1)
                        {
                            var textSqlText = string.Format(textTemplateSqlText, match1[0].Groups[1].Value, indexName, "删除" + remark);
                            createSqlTexts.Add(textSqlText);
                        }
                    }
                }
                //输出删除索引
                File.WriteAllLines("DeleteIndexSql\\" + fileName + "-删除索引.sql", createSqlTexts.ToArray(), Encoding.GetEncoding("GB2312"));
            }
        }
    }
}
