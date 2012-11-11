namespace Me.Amon.Open
{
    public class OAuthConsumer
    {
        public string consumer_key { get; set; }

        public string consumer_secret { get; set; }

        public static OAuthConsumer KuaipanConsumer()
        {
            var consumer = new OAuthConsumer();
            consumer.consumer_key = "xcWPaz75PSRDOWBM";
            consumer.consumer_secret = "DU5ZYaCK0cRlsMTj";
            return consumer;
        }

        public static OAuthConsumer DropboxConsumer()
        {
            var consumer = new OAuthConsumer();
            consumer.consumer_key = "jq3s8fjnniw610v";
            consumer.consumer_secret = "zh7c4caji3mecss";
            return consumer;
        }

        public static OAuthConsumer SkydriveConsumer()
        {
            var consumer = new OAuthConsumer();
            consumer.consumer_key = "00000000440DFA3C";
            consumer.consumer_secret = "qu9zeUeXgIJVClxaJr6tplLBolpXrw8A";
            return consumer;
        }
    }
}
