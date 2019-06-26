using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using Microsoft.Office.Core; 

namespace Maticsoft.Common
{
    public class OfficeToHtml
    {
        /// <summary> 
        /// word转成html  
        /// </summary> 
        /// <param name="path">要转换的文档的路径</param> 
        /// <param name="savePath">转换成的html的保存路径</param> 
        /// <param name="wordFileName">转换后html文件的名字</param> 
        //private static void WordToHtml(string path, string savePath, string wordFileName)
        //{
        //    Word.ApplicationClass word = new Word.ApplicationClass();
        //    Type wordwordType = word.GetType();
        //    Word.Documents docs = word.Documents;
        //    Type docsdocsType = docs.GetType();
        //    Word.Document doc = (Word.Document)docsType.InvokeMember("Open", System.Reflection.BindingFlags.InvokeMethod, null, docs, new Object[] { (object)path, true, true });
        //    Type docdocType = doc.GetType();
        //    string strSaveFileName = savePath + wordFileName + ".html";
        //    object saveFileName = (object)strSaveFileName;
        //    docType.InvokeMember("SaveAs", System.Reflection.BindingFlags.InvokeMethod, null, doc, new object[] { saveFileName, Word.WdSaveFormat.wdFormatFilteredHTML });
        //    docType.InvokeMember("Close", System.Reflection.BindingFlags.InvokeMethod, null, doc, null);
        //    wordType.InvokeMember("Quit", System.Reflection.BindingFlags.InvokeMethod, null, word, null);
        //}
        private static void WordToHtml(string path)
        {
            Word.Application word = new Word.Application();
            Type wordType = word.GetType();
            Word.Documents docs = word.Documents;
            Type docsType = docs.GetType();
            Word.Document doc = (Word.Document)docsType.InvokeMember("Open", System.Reflection.BindingFlags.InvokeMethod, null, docs, new Object[] { (object)path, true, true });
            Type docdocType = doc.GetType();
            string strSaveFileName = path.Substring(0, path.Length - 3) + ".html";
            object saveFileName = (object)strSaveFileName;
            docsType.InvokeMember("SaveAs", System.Reflection.BindingFlags.InvokeMethod, null, doc, new object[] { saveFileName, Word.WdSaveFormat.wdFormatFilteredHTML });
            docsType.InvokeMember("Close", System.Reflection.BindingFlags.InvokeMethod, null, doc, null);
            wordType.InvokeMember("Quit", System.Reflection.BindingFlags.InvokeMethod, null, word, null);
        }

        public static string WordToHtml(object wordfilename)
        {
            //在此处放置用户代码以初始化页面   
            Word.Application word = new Word.Application();
            Type wordtype = word.GetType();
            Word.Documents docs = word.Documents;
            //打开文件   
            Type docstype = docs.GetType();
            Word.Document doc = (Word.Document)docstype.InvokeMember("open", System.Reflection.BindingFlags.InvokeMethod, null, docs, new object[] { wordfilename, true, true });
            //转换格式，另存为   
            Type doctype = doc.GetType();
            string wordsavefilename = wordfilename.ToString();
            string strsavefilename = wordsavefilename.Substring(0, wordsavefilename.Length - 3) + "html";
            object savefilename = (object)strsavefilename;
            doctype.InvokeMember("saveas", System.Reflection.BindingFlags.InvokeMethod, null, doc, new object[] { savefilename, Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatFilteredHTML });
            doctype.InvokeMember("close", System.Reflection.BindingFlags.InvokeMethod, null, doc, null);
            // 退出 word   
            wordtype.InvokeMember("quit", System.Reflection.BindingFlags.InvokeMethod, null, word, null);
            return savefilename.ToString();
        }  

        /// <summary> 
        /// excel 转换为html  
        /// </summary> 
        /// <param name="path">要转换的文档的路径</param> 
        /// <param name="savePath">转换成的html的保存路径</param> 
        /// <param name="wordFileName">转换后html文件的名字</param> 
        public static void ExcelToHtml(string path, string savePath, string wordFileName)
        {
            string str = string.Empty;
            Microsoft.Office.Interop.Excel.Application repExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workbook = null;
            Microsoft.Office.Interop.Excel.Worksheet worksheet = null;
            workbook = repExcel.Application.Workbooks.Open(path, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];
            object htmlFile = savePath + wordFileName + ".html";
            object ofmt = Microsoft.Office.Interop.Excel.XlFileFormat.xlHtml;
            workbook.SaveAs(htmlFile, ofmt, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            object osave = false;
            workbook.Close(osave, Type.Missing, Type.Missing);
            repExcel.Quit();
        }

        public static void ExcelToHtml(string path)
        {
            string str = string.Empty;
            Microsoft.Office.Interop.Excel.Application repExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workbook = null;
            Microsoft.Office.Interop.Excel.Worksheet worksheet = null;
            workbook = repExcel.Application.Workbooks.Open(path, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];
            object htmlFile = path.Substring(0, path.Length - 3) + ".html";
            object ofmt = Microsoft.Office.Interop.Excel.XlFileFormat.xlHtml;
            workbook.SaveAs(htmlFile, ofmt, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            object osave = false;
            workbook.Close(osave, Type.Missing, Type.Missing);
            repExcel.Quit();
        }

        //public string ExcelToHtml(string excelFileName)
        //{
        //    //实例化Excel  
        //    Microsoft.Office.Interop.Excel.Application repExcel = new Microsoft.Office.Interop.Excel.Application();
        //    Microsoft.Office.Interop.Excel.Workbook workbook = null;
        //    Microsoft.Office.Interop.Excel.Worksheet worksheet = null;
        //    //打开文件，n.FullPath是文件路径  
        //    workbook = repExcel.Application.Workbooks.Open(excelFileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
        //    worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];
        //    string filesavefilename = excelFileName.ToString();
        //    string strsavefilename = filesavefilename.Substring(0, filesavefilename.Length - 3) + "html";
        //    object savefilename = (object)strsavefilename;
        //    object ofmt = Microsoft.Office.Interop.Excel.XlFileFormat.xlHtml;
        //    //进行另存为操作    
        //    workbook.SaveAs(savefilename, ofmt, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
        //    object osave = false;
        //    //逐步关闭所有使用的对象  
        //    workbook.Close(osave, Type.Missing, Type.Missing);
        //    repExcel.Quit();
        //    System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
        //    worksheet = null;
        //    //垃圾回收  
        //    GC.Collect();
        //    System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
        //    workbook = null;
        //    GC.Collect();
        //    System.Runtime.InteropServices.Marshal.ReleaseComObject(repExcel.Application.Workbooks);
        //    GC.Collect();
        //    System.Runtime.InteropServices.Marshal.ReleaseComObject(repExcel);
        //    repExcel = null;
        //    GC.Collect();
        //    //依据时间杀灭进程  
        //    System.Diagnostics.Process[] process = System.Diagnostics.Process.GetProcessesByName("EXCEL");
        //    foreach (System.Diagnostics.Process p in process)
        //    {
        //        if (DateTime.Now.Second - p.StartTime.Second > 0 && DateTime.Now.Second - p.StartTime.Second < 5)
        //        {
        //            p.Kill();
        //        }
        //    }

        //    return savefilename.ToString();
        //}  

        /// <summary> 
        /// ppt转换为html  
        /// </summary> 
        /// <param name="path">要转换的文档的路径</param> 
        /// <param name="savePath">转换成的html的保存路径</param> 
        /// <param name="wordFileName">转换后html文件的名字</param> 
        public static void PPTToHtml(string path, string savePath, string wordFileName)
        {
            Microsoft.Office.Interop.PowerPoint.Application ppApp = new Microsoft.Office.Interop.PowerPoint.Application();
            string strSourceFile = path;
            string strDestinationFile = savePath + wordFileName + ".html";
            Microsoft.Office.Interop.PowerPoint.Presentation prsPres = ppApp.Presentations.Open(strSourceFile, Microsoft.Office.Core.MsoTriState.msoTrue, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoFalse);
            prsPres.SaveAs(strDestinationFile, Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsHTML, MsoTriState.msoTrue);
            prsPres.Close();
            ppApp.Quit();
        }

        public static void PPTToHtml(string path)
        {
            Microsoft.Office.Interop.PowerPoint.Application ppApp = new Microsoft.Office.Interop.PowerPoint.Application();
            string strSourceFile = path;
            string strDestinationFile = path.Substring(0, path.Length - 3) + ".html";
            Microsoft.Office.Interop.PowerPoint.Presentation prsPres = ppApp.Presentations.Open(strSourceFile, Microsoft.Office.Core.MsoTriState.msoTrue, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoFalse);
            prsPres.SaveAs(strDestinationFile, Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsHTML, MsoTriState.msoTrue);
            prsPres.Close();
            ppApp.Quit();
        }

        //public string PPTToHtml(object pptFilename)
        //{
        //    //被转换的html文档保存的位置  
        //    string saveFileName = pptFilename + ".html";
        //    Microsoft.Office.Interop.PowerPoint.Application ppt = new Microsoft.Office.Interop.PowerPoint.Application();
        //    Microsoft.Office.Core.MsoTriState m1 = new MsoTriState();
        //    Microsoft.Office.Core.MsoTriState m2 = new MsoTriState();
        //    Microsoft.Office.Core.MsoTriState m3 = new MsoTriState();
        //    Microsoft.Office.Interop.PowerPoint.Presentation pp = ppt.Presentations.Open(pptFilename, m1, m2, m3);
        //    pp.SaveAs(saveFileName, Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsHTML, Microsoft.Office.Core.MsoTriState.msoTriStateMixed);
        //    pp.Close();
        //    //返回文件名  
        //    return saveFileName;
        //}  
    }
}
