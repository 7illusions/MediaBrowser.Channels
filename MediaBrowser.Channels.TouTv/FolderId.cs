﻿using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace MediaBrowser.Channels.TouTv
{
    internal class FolderId
    {
        public FolderIdType FolderIdType { get; private set; }
        public string Id { get; private set; }

        public static FolderId ParseFolderId(string folderId)
        {
            if (string.IsNullOrEmpty(folderId))
            {
                return new FolderId(FolderIdType.Home);
            }
            var match = Regex.Match(folderId, "(?<type>.*?)-(?<id>.*)?");
            if (match.Success)
            {
                FolderIdType type;
                if (Enum.TryParse(match.Groups["type"].Value, out type))
                {
                    var result = new FolderId(type);
                    var id = match.Groups["id"];
                    if (id != null)
                    {
                        result.Id = id.Value;
                    }
                    return result;
                }
            }
            throw new ArgumentException("Argument format is not recognized. Only pass string which have been returned by FolderId.ToString().", "folderId");
        }

        public static FolderId CreateGenresFolderId()
        {
            return new FolderId(FolderIdType.Genres);
        }

        public static FolderId CreateGenreFolderId(long genreId)
        {
            var id = genreId.ToString(CultureInfo.InvariantCulture);
            return new FolderId(FolderIdType.Genre, id);
        }

        public static FolderId CreateShowsFolderId()
        {
            return new FolderId(FolderIdType.Shows);
        }

        public static FolderId CreateShowFolderId(long showId)
        {
            var id = showId.ToString(CultureInfo.InvariantCulture);
            return new FolderId(FolderIdType.Show, id);
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(Id))
            {
                return FolderIdType + "-";
            }
            return string.Format("{0}-{1}", FolderIdType, Id);
        }

        private FolderId(FolderIdType folderIdType, string id = null)
        {
            FolderIdType = folderIdType;
            if (!string.IsNullOrEmpty(id))
            {
                Id = id;
            }
        }
    }
}
