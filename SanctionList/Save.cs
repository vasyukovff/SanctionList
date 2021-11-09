using OfficeOpenXml;
using SanctionList.Dto;

namespace SanctionList
{
    public class Save
    {
        private static readonly string FolderPath = "";

        static Save()
        {
            FolderPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\FSF Results\";
        }

        public static bool SaveObjectsToCSV(List<ObjectDto> objects, string searchTerm, out string fileName)
        {

            fileName = $"{DateTime.Now.ToFileNameFormatString()} [{searchTerm}].csv";

            try
            {
                var package = new ExcelPackage();
                var sheet = package.Workbook.Worksheets.Add("Sanction list");

                sheet.Cells[1, 1].Value = "Search name term (input)";
                sheet.Cells[1, 2].Value = "id";
                sheet.Cells[1, 3].Value = "caption";
                sheet.Cells[1, 4].Value = "schema";
                sheet.Cells[1, 5].Value = "properties.alias";
                sheet.Cells[1, 6].Value = "properties.sanctions.caption";
                sheet.Cells[1, 7].Value = "properties.sanctions.dataset";
                sheet.Cells[1, 8].Value = "properties.sanctions.id";
                sheet.Cells[1, 9].Value = "properties.sanctions.properties.authority";
                sheet.Cells[1, 10].Value = "properties.sanctions.properties.country";
                sheet.Cells[1, 11].Value = "properties.sanctions.properties.entity";
                sheet.Cells[1, 12].Value = "properties.sanctions.properties.program";
                sheet.Cells[1, 13].Value = "properties.sanctions.properties.sourceUrl";

                int row = 2;

                foreach(var obj in objects)
                {
                    sheet.Cells[row, 1].Value = searchTerm;
                    sheet.Cells[row, 2].Value = obj.Id;
                    sheet.Cells[row, 3].Value = obj.Caption;
                    sheet.Cells[row, 4].Value = obj.Schema;
                    sheet.Cells[row, 5].Value = obj.Properties.Alias;
                    sheet.Cells[row, 6].Value = obj.Properties.Sanctions.FirstOrDefault()?.Caption;
                    sheet.Cells[row, 7].Value = obj.Properties.Sanctions.FirstOrDefault()?.Dataset;
                    sheet.Cells[row, 8].Value = obj.Properties.Sanctions.FirstOrDefault()?.Id;
                    sheet.Cells[row, 9].Value = obj.Properties.Sanctions.FirstOrDefault()?.Properties.Authority;
                    sheet.Cells[row, 10].Value = obj.Properties.Sanctions.FirstOrDefault()?.Properties.Country;
                    sheet.Cells[row, 11].Value = obj.Properties.Sanctions.FirstOrDefault()?.Properties.Entity;
                    sheet.Cells[row, 12].Value = obj.Properties.Sanctions.FirstOrDefault()?.Properties.Program;
                    sheet.Cells[row, 13].Value = obj.Properties.Sanctions.FirstOrDefault()?.Properties.SourceUrl;

                    row++;
                }

                ValidFolderPath();
                package.SaveAs(new FileInfo(FolderPath + fileName));

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        private static void ValidFolderPath()
        {
            if (!Directory.Exists(FolderPath)) Directory.CreateDirectory(FolderPath);
        }
    }
}
