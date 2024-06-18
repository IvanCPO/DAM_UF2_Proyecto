using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EvolutionController : MonoBehaviour
{
    [SerializeField] AudioClip song;
    [SerializeField] GameObject panelButtons;
    [SerializeField] GameObject message;
    [SerializeField] Text textPre;
    [SerializeField] Text textPos;
    [SerializeField] Image picturePokemon;
    [SerializeField] GameObject dialEvolution;
    [SerializeField] Text textEvolution;
    [SerializeField] GameObject dialMove;
    [SerializeField] Text textMove;
    [SerializeField] NewMoveController newMove;
    private ListEvolutionsController list;
    private AudioSource reproductor;
    private StatusPlayer status;
    private Pokemon prEvolution;
    private Pokemon evolution;
    public float speed;
    private float count;

    public void Start(){
        status = StatusPlayer.getInstance();
        reproductor = gameObject.GetComponent<AudioSource>();
        status = StatusPlayer.getInstance();
        list = ListEvolutionsController.GetListInstance();

        //for test
        if (status.GetTeam().Count==0)
        {
            Pokemon pokemon = new Pokemon(PokemonBase.GetPokemonBase(10),7);
            status.GetTeam().Add(pokemon);
            list.AddPokemon(pokemon);
            // pokemon = new Pokemon(PokemonBase.GetPokemonBase(4),1);
            // status.GetTeam().Add(pokemon);
            // list.AddPokemon(pokemon);
        }

        
        count = 0;
        SetData();
    }

    public void Update(){
        if (count!=0f)
        {
            picturePokemon.fillAmount +=count;
            if (picturePokemon.fillAmount==1 || picturePokemon.fillAmount==0)
            {
                count = 0f;
            }
        }
        if (newMove.IsDecided())
        {
            evolution = HitsController.GetInstance().Player;
            status.GetTeam().Add(evolution);
            evolution=null;
            newMove.Clear();
            ChangeEvolution();

        }
    }
    
    private void SetData(){
        dialEvolution.SetActive(false);
        dialMove.SetActive(false);
        panelButtons.SetActive(true);
        message.SetActive(true);
        textPre.text = list.GetPokemons()[0].Base.Name;
        picturePokemon.sprite = list.GetPokemons()[0].Base.FrontSprite;
        prEvolution = list.GetPokemons()[0];
        evolution = list.GenerateEvolution();
        textPos.text = evolution.Base.Name;
    }

    public void CancelEvolution(){
        evolution = null;
        dialEvolution.SetActive(false);
        dialMove.SetActive(false);
        panelButtons.SetActive(false);
        message.SetActive(false);
        ChangeEvolution();
    }  

    public void AcceptEvolution(){
        Evolution();
    }

    private void ChangeEvolution(){
        if (evolution!=null)
        {
            MoveBase move = evolution.isLearning();
            if (move!=null)
            {
                LearnMoves(move);
            }else{
                status.GetTeam().Add(evolution);
                status.GetMeets().Add(evolution.Base.PokedexID);
                evolution = null;
                ChangeEvolution();
            }
        }else{
            Debug.Log("Check");
            if(list.GetPokemons().Count==0){
                Invoke("Close",3f);
            }else{
                Invoke("SetData",3f);
            }
        }
    }

    private void LearnMoves(MoveBase move){
        
        if (evolution.LearnAlone(move)){
            dialMove.SetActive(true);
            textMove.text = "Tu pokemon ha aprendido "+move.Name;
            status.GetTeam().Add(evolution);
            status.GetMeets().Add(evolution.Base.PokedexID);
            evolution=null;
            Invoke("ChangeEvolution",2.5f);
        }else
        {
            newMove.LearnMove(evolution, move);
        }
    }
    
    private void Evolution(){
        panelButtons.SetActive(false);
        message.SetActive(false);
        count= (-1)*speed;
        status.GetTeam().Remove(prEvolution);
        Invoke("ChangePokemon",2.5f);
        Invoke("ChangeEvolution",5f);
    }

    private void ChangePokemon(){
        count= speed;
        picturePokemon.sprite = evolution.Base.FrontSprite;
        dialEvolution.SetActive(true);
        textEvolution.text = "O teu pokemon evolucionou, agora é "+evolution.Base.Name;
    }

    private void Close(){
        SceneManager.LoadScene(status.getUbicationActual().SceneId);
    }

}
