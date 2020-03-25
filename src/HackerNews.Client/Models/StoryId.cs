namespace HackerNews.Client.Models
{
    public struct StoryId
    {
        public long Value { get; set; }

        public static implicit operator string(StoryId story) => $"{story.Value}.json";
    }

}