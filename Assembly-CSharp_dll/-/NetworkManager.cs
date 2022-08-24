private void Update()
{
  if (PhotonNetwork.IsConnected && Time.frameCount % 10 == 0 && this.rrc != PhotonNetwork.ResentReliableCommands)
  {
    this.rrc = PhotonNetwork.ResentReliableCommands;
    Debug.LogError("PhotonNetwork.ResentReliableCommands=>" + this.rrc.ToString());
  }
  if (Input.GetKeyDown(KeyCode.F2))
  {
    this.TwitchMessage("bot1", "test1");
    this.TwitchMessage("bot2", "test2");
    this.TwitchMessage("botato", "pog");
  }
}

public string Sanitize(string str)
{
  return Regex.Replace(str, "[^0-9a-zA-Z -.:;=?@^_]+", "");
}

public void TwitchMessage(string usr, string msg)
{
  string[] colors = new string[]
  {
    "FF0000",
    "800000",
    "FFFF00",
    "808000",
    "00FF00",
    "008000",
    "00FFFF",
    "008080",
    "0000FF",
    "000080",
    "FF00FF",
    "800080"
  };
  int i = 0;
  foreach (byte b in Encoding.UTF8.GetBytes(usr))
  {
    i += (int)b;
  }
  StringBuilder sb = new StringBuilder();
  sb.Append("<b><color=#8A2BE2>[T]</color><color=#");
  sb.Append(colors[i % colors.Length]);
  sb.Append(">");
  sb.Append(this.Sanitize(usr));
  sb.Append("</color></b>: ");
  sb.Append(this.Sanitize(msg));
  this.ChatSend(sb.ToString(), false);
}
