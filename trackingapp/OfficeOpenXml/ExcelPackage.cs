namespace OfficeOpenXml
{
    internal class ExcelPackage
    {
        public ExcelPackage()
        {
        }

        public object Workbook { get; internal set; }

        internal void Dispose()
        {
            throw new NotImplementedException();
        }

        internal void SaveAs(MemoryStream stream)
        {
            throw new NotImplementedException();
        }

        internal void SaveAs(FileInfo fileInfo)
        {
            throw new NotImplementedException();
        }
    }
}