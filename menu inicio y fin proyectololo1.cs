public Text mensajeText;
mensajeText = GameObject.Find("Mensaje").GetComponent<Text>();
mensajeText.text = "¡Has ganado!";
IEnumerator OcultarMensaje()
{
    yield return new WaitForSeconds(3);
    mensajeText.text = "";
}
StartCoroutine(OcultarMensaje());
