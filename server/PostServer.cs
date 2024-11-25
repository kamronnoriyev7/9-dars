using Post_CRUD.Model;

namespace Post_CRUD.Service;

public class PostService
{
    private List<Post> posts;

    public PostService()
    {
        posts = new List<Post>();
    }
    
    public Post AddPost(Post post)
    {
        post.Id = Guid.NewGuid();
        posts.Add(post);
       
        return post;
    }

    public Post UpdatePost(Post postId)
    {
        foreach (var post in posts)
        {
            if (postId.Id == post.Id)
            {
                AddPost(post);
                return post;
            }
        }

        return null;
    }

    public Post DeletePost(Post postId)
    {
        foreach (var post in posts)
        {
            if (postId.Id == post.Id)
            {
                posts.Remove(post);
                return post;
            }
        }

        return null;
    }


    public Post GetPostId(Guid postId)
    {
        foreach (var post in posts)
        {
            if (postId == post.Id)
            {
                return post;
            }
        }

        return null;
    }

    public List<Post> GetAllPosts()
    {
        return posts; 
    }


    public Post GetMostViewedPost(List<Post> posts)
    {
        var maxInt = int.MinValue;
        Post mostViewedPost = null;
        foreach (var post in posts)
        {
            if (posts.Count > maxInt)
            {
                maxInt = posts.Count;
                mostViewedPost = post;
            }
        }

        return mostViewedPost;
    }

    public Post GetMostLikedPost(List<Post> posts)
    {
        var maxInt = int.MinValue;
        Post mostLikedPost = null;
        foreach (var post in posts)
        {
            if (posts.Count > maxInt)
            {
                maxInt = posts.Count;
                mostLikedPost = post;
            }
        }

        return mostLikedPost;
    }

    public Post GetMostCommentedPost()
    {
        var maxInt = int.MinValue;
        Post mostCommentPost = null;
        foreach (var post in posts)
        {
            if (posts.Count > maxInt)
            {
                maxInt = posts.Count;
                mostCommentPost = post;
            }
        }

        return mostCommentPost;
    }

    public List<Post> GetPostsByComment(string comment)
    {
        posts = new List<Post>();
        foreach (var post in posts)
        {
            foreach (var comment1 in post.Comments)
            {
                if (comment == comment1)
                {
                    posts.Add(post);
                }
            }
        }

        return posts;
    }

    public bool AddCommentToPost(Guid postId, string comment)
    {
        foreach (var post in posts)
        {
            if (postId == post.Id)
            {
                post.Comments.Add(comment);
                return true;
            }
        }

        return false;
    }

    public bool RemoveCommentFromPost(Guid postId, string comment)
    {
        foreach (var element in posts)
        {
            var post = GetById(postId);
            if (postId == element.Id)
            {
                post.Comments.Remove(comment);
                return true;
            }
        }
        return false;
    }

    public Post GetById(Guid postId)
    {
        foreach (var element in posts)
        {
            if (element.Id == postId)
                return element;
        }
        return null;
    }


}