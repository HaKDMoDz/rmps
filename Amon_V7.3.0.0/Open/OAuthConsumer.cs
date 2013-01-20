namespace Me.Amon.Open
{
    public class OAuthConsumer
    {
        public string consumer_key { get; set; }

        public string consumer_secret { get; set; }

        public static OAuthConsumer KuaipanConsumer()
        {
            var consumer = new OAuthConsumer();
            //consumer.consumer_key = "xcWPaz75PSRDOWBM";
            //consumer.consumer_secret = "DU5ZYaCK0cRlsMTj";
            consumer.consumer_key = "xcLegJ8HLq7ZoQ0U";
            consumer.consumer_secret = "psaBwFH0Z0r2PEPI";
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

        public static OAuthConsumer KanboxConsumer()
        {
            var consumer = new OAuthConsumer();
            consumer.consumer_key = "b00631e8019dd71afd23423da813fd3b";
            consumer.consumer_secret = "2553032e836e4de9d2e6a6bc2628c437";
            return consumer;
        }
    }
}
