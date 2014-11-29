namespace _02.TraverseWindowsDirectory
{
    using System.Collections.Generic;
    using System.Linq;

    public class SysFolder
    {
        private ICollection<SysFile> files;
        private ICollection<SysFolder> subFolders;

        public SysFolder(string name)
        {
            this.Name = name;
            this.files = new List<SysFile>();
            this.subFolders = new List<SysFolder>();
        }

        public string Name { get; set; }

        public ICollection<SysFile> Files
        {
            get
            {
                return this.files;
            }
            set
            {
                this.files = value;
            }
        }

        public ICollection<SysFolder> SubFolders
        {
            get
            {
                return this.subFolders;
            }
            set
            {
                this.subFolders = value;
            }
        }

        public override string ToString()
        {
            return this.Name;
        }

        public long GetSizeFromHere()
        {
            return this.Files.Sum(f => f.Size) + this.SubFolders.Sum(f => f.GetSizeFromHere());
        }
    }
}
