using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

public class Comment
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    private string _id;

    private string _text;

    public Comment(string text)
    {
        _text = text;

    }
}