using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TwitterClone.App_Code.Posts;

namespace TwitterClone
{
    public partial class Default : System.Web.UI.Page
    {
        public IEnumerable<Posts> posts = new List<Posts>();


        //added this one
        public Posts currentPost = new Posts()
        {
            Content = "Hello new new world",
            PostedBy = "joblipat"
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            var postRepository = new PostRepository();
            posts = postRepository.GetAllPosts();

            //PostRepeater.DataSource = posts;
            //PostRepeater.DataBind();
        }
    }
}