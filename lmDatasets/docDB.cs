namespace lmDatasets {
    
    
    public partial class docDB {
        partial class RecipientDataTable
        {
        }
    
        partial class DocumentDataTable
        {
        }

        public partial class DocumentRow : System.Data.DataRow
        {
            public string Name
            {
                get
                {
                    string file=this.efSubject;
                    if (file.Length > 128)
                        file = file.Substring(0, 128);

                    if (this.DocContentRow != null && !this.DocContentRow.IsExtNull())
                        file += this.DocContentRow.Ext;
                    else if (!this.IsextNull())
                        file += this.ext;

                    foreach (char c in System.IO.Path.GetInvalidFileNameChars())
                    {
                        file = file.Replace(c, '_');
                    }
                    return file;
 
                }
            }

            public DocContentRow DocContentRow
            {
                get
                {
                    if(this.GetDocContentRows().Length==0)
                        return null;
                    else
                        return (DocContentRow)this.GetDocContentRows()[0];
                    
                        
                }
            }

         }

        public partial class DocContentRow : System.Data.DataRow
        {
        
            public string ContentsAsText
            {
                get
                {
                    if (Contents == null)
                        return null;
                    else
                    {
                        return System.Text.Encoding.Default.GetString(Contents);
                    }
                }
                set
                {
                    if (value != null)
                        Contents = System.Text.Encoding.Default.GetBytes(value);
                    else
                        this.SetContentsNull();
                }
            }

        }
    }
}
