﻿//---------------------------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated by T4Model template for T4 (https://github.com/linq2db/linq2db).
//    Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//---------------------------------------------------------------------------------------------------

#pragma warning disable 1591

using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

namespace Blog.DataAccess
{
	/// <summary>
	/// Database       : Blog
	/// Data Source    : .
	/// Server Version : 14.00.1000
	/// </summary>
	public partial class BlogDB : LinqToDB.Data.DataConnection
	{
		public ITable<Comment>    Comments     { get { return this.GetTable<Comment>(); } }
		public ITable<Post>       Posts        { get { return this.GetTable<Post>(); } }
		public ITable<PostStatus> PostStatuses { get { return this.GetTable<PostStatus>(); } }
		public ITable<Role>       Roles        { get { return this.GetTable<Role>(); } }
		public ITable<User>       Users        { get { return this.GetTable<User>(); } }

		public BlogDB()
		{
			InitDataContext();
			InitMappingSchema();
		}

		public BlogDB(string configuration)
			: base(configuration)
		{
			InitDataContext();
			InitMappingSchema();
		}

		partial void InitDataContext  ();
		partial void InitMappingSchema();
	}

	[Table(Schema="dbo", Name="Comments")]
	public partial class Comment
	{
		[Column("id"), PrimaryKey, Identity] public int    Id     { get; set; } // int
		[Column(),     NotNull             ] public int    UserId { get; set; } // int
		[Column(),     NotNull             ] public string Text   { get; set; } // nvarchar(255)
		[Column(),     NotNull             ] public int    PostId { get; set; } // int

		#region Associations

		/// <summary>
		/// FK_Comments_Posts
		/// </summary>
		[Association(ThisKey="PostId", OtherKey="Id", CanBeNull=false, Relationship=Relationship.ManyToOne, KeyName="FK_Comments_Posts", BackReferenceName="Comments")]
		public Post Post { get; set; }

		/// <summary>
		/// FK_Comments_Users
		/// </summary>
		[Association(ThisKey="UserId", OtherKey="Id", CanBeNull=false, Relationship=Relationship.ManyToOne, KeyName="FK_Comments_Users", BackReferenceName="Comments")]
		public User User { get; set; }

		#endregion
	}

	[Table(Schema="dbo", Name="Posts")]
	public partial class Post
	{
		[PrimaryKey, Identity   ] public int      Id          { get; set; } // int
		[Column,        Nullable] public int?     ParentId    { get; set; } // int
		[Column,     NotNull    ] public string   Text        { get; set; } // nvarchar(255)
		[Column,     NotNull    ] public int      UserId      { get; set; } // int
		[Column,     NotNull    ] public int      StatusId    { get; set; } // int
		[Column,     NotNull    ] public DateTime CreatedDate { get; set; } // datetime
		[Column,     NotNull    ] public DateTime UpdatedDate { get; set; } // datetime

		#region Associations

		/// <summary>
		/// FK_Comments_Posts_BackReference
		/// </summary>
		[Association(ThisKey="Id", OtherKey="PostId", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
		public IEnumerable<Comment> Comments { get; set; }

		/// <summary>
		/// FK_Posts_Posts_BackReference
		/// </summary>
		[Association(ThisKey="Id", OtherKey="ParentId", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
		public IEnumerable<Post> FkPostsPostsBackReferences { get; set; }

		/// <summary>
		/// FK_Posts_Posts
		/// </summary>
		[Association(ThisKey="ParentId", OtherKey="Id", CanBeNull=true, Relationship=Relationship.ManyToOne, KeyName="FK_Posts_Posts", BackReferenceName="FkPostsPostsBackReferences")]
		public Post Parent { get; set; }

		/// <summary>
		/// FK_Posts_PostStatuses
		/// </summary>
		[Association(ThisKey="StatusId", OtherKey="Id", CanBeNull=false, Relationship=Relationship.ManyToOne, KeyName="FK_Posts_PostStatuses", BackReferenceName="Posts")]
		public PostStatus Status { get; set; }

		/// <summary>
		/// FK_Posts_Users
		/// </summary>
		[Association(ThisKey="UserId", OtherKey="Id", CanBeNull=false, Relationship=Relationship.ManyToOne, KeyName="FK_Posts_Users", BackReferenceName="Posts")]
		public User User { get; set; }

		#endregion
	}

	[Table(Schema="dbo", Name="PostStatuses")]
	public partial class PostStatus
	{
		[PrimaryKey, NotNull] public int    Id     { get; set; } // int
		[Column,     NotNull] public string Status { get; set; } // nchar(10)

		#region Associations

		/// <summary>
		/// FK_Posts_PostStatuses_BackReference
		/// </summary>
		[Association(ThisKey="Id", OtherKey="StatusId", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
		public IEnumerable<Post> Posts { get; set; }

		#endregion
	}

	[Table(Schema="dbo", Name="Roles")]
	public partial class Role
	{
		[PrimaryKey, Identity] public int    Id       { get; set; } // int
		[Column,     NotNull ] public string RoleName { get; set; } // varchar(50)

		#region Associations

		/// <summary>
		/// FK_Users_Roles_BackReference
		/// </summary>
		[Association(ThisKey="Id", OtherKey="RoleId", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
		public IEnumerable<User> Users { get; set; }

		#endregion
	}

	[Table(Schema="dbo", Name="Users")]
	public partial class User
	{
		[PrimaryKey, Identity   ] public int    Id       { get; set; } // int
		[Column,     NotNull    ] public string UserName { get; set; } // nvarchar(50)
		[Column,     NotNull    ] public string Password { get; set; } // nvarchar(50)
		[Column,        Nullable] public int?   RoleId   { get; set; } // int

		#region Associations

		/// <summary>
		/// FK_Comments_Users_BackReference
		/// </summary>
		[Association(ThisKey="Id", OtherKey="UserId", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
		public IEnumerable<Comment> Comments { get; set; }

		/// <summary>
		/// FK_Posts_Users_BackReference
		/// </summary>
		[Association(ThisKey="Id", OtherKey="UserId", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
		public IEnumerable<Post> Posts { get; set; }

		/// <summary>
		/// FK_Users_Roles
		/// </summary>
		[Association(ThisKey="RoleId", OtherKey="Id", CanBeNull=true, Relationship=Relationship.ManyToOne, KeyName="FK_Users_Roles", BackReferenceName="Users")]
		public Role Role { get; set; }

		#endregion
	}

	public static partial class TableExtensions
	{
		public static Comment Find(this ITable<Comment> table, int Id)
		{
			return table.FirstOrDefault(t =>
				t.Id == Id);
		}

		public static Post Find(this ITable<Post> table, int Id)
		{
			return table.FirstOrDefault(t =>
				t.Id == Id);
		}

		public static PostStatus Find(this ITable<PostStatus> table, int Id)
		{
			return table.FirstOrDefault(t =>
				t.Id == Id);
		}

		public static Role Find(this ITable<Role> table, int Id)
		{
			return table.FirstOrDefault(t =>
				t.Id == Id);
		}

		public static User Find(this ITable<User> table, int Id)
		{
			return table.FirstOrDefault(t =>
				t.Id == Id);
		}
	}
}

#pragma warning restore 1591
