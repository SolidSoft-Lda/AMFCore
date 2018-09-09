using System.Text.RegularExpressions;

using SolidSoft.AMFCore.Exceptions;

namespace SolidSoft.AMFCore.Messaging.Services.Messaging
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// Represents a message destination subtopic.
	/// 
	/// The subtopic feature lets you divide the messages that a Producer component sends to a destination into specific categories at the destination.
	/// Configure a Consumer component that subscribes to the destination to receive only messages sent to a specific subtopic or set of subtopics.
	/// Use wildcard characters (*) to send or receive messages from more than one subtopic.
	/// </summary>
	public class Subtopic
	{
		public const string SubtopicWildcard = "*";
		public const string SubtopicSeparator = ".";

		private string _subtopic;
		private string[] _subtopicItems;
		//private string _separator;

		private const string SubtopicCheckExpression = @"^([\w][\w\-]*)(\.(([\w][\w\-]*)|\*))*$|^\*$";
		private static Regex _regex;

		static Subtopic()
		{
			_regex = new Regex(SubtopicCheckExpression, RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Compiled);
		}
        /// <summary>
        /// Initializes a new instance of the Subtopic class.
        /// </summary>
        /// <param name="subtopic"></param>
		public Subtopic(string subtopic):this(subtopic, SubtopicSeparator)
		{
		}

		private Subtopic(string subtopic, string separator)
		{
			if( subtopic == null || subtopic.Length == 0 )
				throw new AMFException(__Res.GetString(__Res.Subtopic_Invalid, string.Empty));
			//_separator = separator;
			if( !_regex.IsMatch(subtopic) )
				throw new AMFException(__Res.GetString(__Res.Subtopic_Invalid, subtopic));
			_subtopic = subtopic;
			_subtopicItems = subtopic.Split(new char[]{ separator[0] });				
		}

		internal string[] SubtopicItems
		{
			get{ return _subtopicItems; }
		}

		/// <summary>
		/// Gets whether the subtopic is hierarchical.
		/// </summary>
		public bool IsHierarchical
		{
			get{ return (_subtopicItems != null && _subtopicItems.Length>1); }
		}

		/// <summary>
		/// Gets the separator used to create this Subtopic instance.
		/// </summary>
		public string Separator
		{
			get{ return SubtopicSeparator; }
		}
		/// <summary>
		/// Gets the subtopic value.
		/// </summary>
		public string Value
		{
			get{ return _subtopic; }
		}
		/// <summary>
		/// Matches the passed subtopic against this subtopic. 
		/// 
		/// If neither subtopic contains a wildcard they must literally match.
		/// If one or the other contains a wildcard they may match. 
		/// 
		/// "chatrooms.*" will match "chatrooms.lobby" or "chatrooms.us.ca" but will not match "chatrooms" (assuming a subtopic separator of "."). 
		/// "chatrooms.*.ca" will match "chatrooms.us.ca" but not "chatrooms.us.ma". 
		/// </summary>
		/// <param name="subtopic">Subtopic object to match against this subtopic.</param>
		/// <returns>True if subtopics match.</returns>
		public bool Matches(Subtopic subtopic)
		{
			if( this.Value == subtopic.Value )
				return true;
			string[] parts1 = this.SubtopicItems;
			string[] parts2 = subtopic.SubtopicItems;
			for(int i = 0; i < parts1.Length; i++)
			{
				string part1 = parts1[i];
				if( part1 == SubtopicWildcard )
					continue;
				if( i >= parts2.Length )
					return true;
				string part2 = parts2[i];
				if( part1 != part2 )
					return false;
			}
			return true;
		}
	}
}