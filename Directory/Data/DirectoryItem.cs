﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeViewsValueConverters.Directory.Data {

    /// <summary>
    /// Information about a directory item such a drive, a file or a folder
    /// </summary>
    public class DirectoryItem {

        /// <summary>
        /// The type of this item
        /// </summary>
        public DirectoryItemType Type { get; set; }

        /// <summary>
        /// The absolute path to this item
        /// </summary>
        public string FullPath { get; set; }

        /// <summary>
        /// The name of this directory
        /// </summary>
        public string Name { get { return Type == DirectoryItemType.Dirve ? FullPath : DirectoryStructure.GetFloderFileName(FullPath); } }
    }

}
