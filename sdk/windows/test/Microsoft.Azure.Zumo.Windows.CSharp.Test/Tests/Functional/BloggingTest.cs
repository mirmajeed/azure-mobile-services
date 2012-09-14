﻿// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Zumo.Win8.Test;
using Microsoft.WindowsAzure.MobileServices;

namespace Microsoft.Azure.Zumo.Win8.CSharp.Test
{
    [DataTable(Name = "blog_posts")]
    public class BlogPost
    {
        public int Id { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "commentCount")]
        public int CommentCount { get; set; }
    }

    [DataTable(Name = "blog_comments")]
    public class BlogComment
    {
        public int Id { get; set; }

        [DataMember(Name = "postid")]
        public int BlogPostId { get; set; }

        [DataMember(Name = "name")]
        public string UserName { get; set; }

        [DataMember(Name = "commentText")]
        public string Text { get; set; }
    }

    [DataContract(Name = "blog_posts")]
    internal class DataContractBlogPost
    {
        [DataMember]
        public int Id;

        [DataMember(Name = "title")]
        public string Title;

        [DataMember(Name = "commentCount")]
        public int CommentCount { get; set; }
    }

    public class BloggingTest : FunctionalTestBase
    {
        [AsyncTestMethod]
        public async Task PostComments()
        {
            MobileServiceClient client = GetClient();
            IMobileServiceTable<BlogPost> postTable = client.GetTable<BlogPost>();
            IMobileServiceTable<BlogComment> commentTable = client.GetTable<BlogComment>();

            // Add a few posts and a comment
            Log("Adding posts");
            BlogPost post = new BlogPost { Title = "Windows 8" };
            await postTable.InsertAsync(post);
            BlogPost highlight = new BlogPost { Title = "ZUMO" };
            await postTable.InsertAsync(highlight);
            await commentTable.InsertAsync(new BlogComment {
                BlogPostId = post.Id,
                UserName = "Anonymous",
                Text = "Beta runs great" });
            await commentTable.InsertAsync(new BlogComment {
                BlogPostId = highlight.Id,
                UserName = "Anonymous",
                Text = "Whooooo" });
            Assert.AreEqual(2, (await postTable.Where(p => p.Id >= post.Id).ToListAsync()).Count);

            // Navigate to the first post and add a comment
            Log("Adding comment to first post");
            BlogPost first = await postTable.LookupAsync(post.Id);
            Assert.AreEqual("Windows 8", first.Title);
            BlogComment opinion = new BlogComment { BlogPostId = first.Id, Text = "Can't wait" };
            await commentTable.InsertAsync(opinion);
            Assert.AreNotEqual(0, opinion.Id);
        }

        [AsyncTestMethod]
        public async Task PostCommentsWithDataContract()
        {
            MobileServiceClient client = GetClient();
            IMobileServiceTable<DataContractBlogPost> postTable = client.GetTable<DataContractBlogPost>();

            // Add a few posts and a comment
            Log("Adding posts");
            DataContractBlogPost post = new DataContractBlogPost() { Title = "How DataContracts Work" };
            await postTable.InsertAsync(post);
            DataContractBlogPost highlight = new DataContractBlogPost { Title = "Using the 'DataMember' attribute" };
            await postTable.InsertAsync(highlight);

            Assert.AreEqual(2, (await postTable.Where(p => p.Id >= post.Id).ToListAsync()).Count);
        }
    }
}
