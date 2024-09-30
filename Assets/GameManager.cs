using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class GameManager : MonoBehaviour
{
  string[] names = {"Over 3.5 vowels", "Over 1.5 same letter", "Top 20 common names (M+F)", "Over 0.5 non-english characters", "Profile verified", "Less than 4.5 letter"};
  string[] distances = {"0 to 5 miles", "5 to 10 miles", "10 to 20 miles", "20 to 30 miles", "30 to 40 miles", "40 to 50 miles", "50+ miles"};
  string[] universities = {"London based uni", "Non-England uni", "Russel Group", "BTEC Uni in the city", "Name of the city begins with B", "Specific subject uni"};
  string[] photoStyles = {"Over 1.5 mirror selfie", "Bathroom", "Drink in hand", "Gym", "Beach", "Snap filter (not background - must be obvious)", "Excessive ass or breast", "Topless for guys/Bikini for girls", "Playing a sport", "Over 3.5 people in 1 pic", "A non-apple phone in shot", "In a restaurant", "0 people in shot", "Pic in car", "Has earphones/headphone", "Sunglasses photo", "Non-phone items inside phone case"};
  string[] appearances = {"Blonde", "Short hair girl/Long hair guy", "Nose ring", "Donald Trump cosplayer (tanned)", "Cake face", "Tattoo visible", "Curly hair", "Not natural hair colour"};
  string[] bios = {"Just for fun",  "States their height",  "My friend made me get this",  "Must be over x height",  "Over 2.5 emojis",  "Over 0.5 emoticons", "Uses xoxo or similar", "Dad joke of any variety", "Could outdrink you", "Buy me x and I'll love you forever", "Over 1.5 abbreviations", "List", "States social media", "Reference to a pet", "Take me to x", "Has country flag", "Won't message first", "Inspirational quote", ">50% on SPaG", "can't think of what to write/what am i meant to write"};
  string[] drinkChoices = {"Wine",  "Beer",  "Cocktails",  "Coffee",  "Gin",  "Tea",  "Espresso martini", "Shots",  "Newly teetotal" };
  string[] dietaryChoices = {"Vegan", "Vegetarian", "Pescatarian", "Kosher", "Halal", "Flexitarian", "Carnivore", "Omnivore"};
  string[] smokingChoices = {"Smoker", "Social smoker", "Smoker when drinking", "Non-smoker"};
  string[] starSigns = {"Capricorn", "Aquarius", "Pisces", "Aries", "Taurus", "Gemini", "Cancer", "Leo", "Virgo", "Libra", "Scorpio", "Sagittarius"};
  string[] textingStyles = {"Big time texter", "Video chatter", "Phone caller", "Bad texter", "Better in person" };
  string[] anthems = {"Release date 2020+", "Not an English song", "Song has over 150m streams on Spotify", "Meme song", "Release date 1970-1990", "YouTube music video over 100m views"};
  string[] topSpotifyArtists = {"Ariana Grande", "Ed Sheeran", "Doja Cat", "The Weeknd", "Eminem", "Bruno Mars", "ABBA", "Dua Lipa",  "Queen", "The Kid LAROI", "Taylor Swift", "Post Malone", "Rhianna", "Calvin Harris", "Coldplay", "Billie Eilish", "Arctic Monkeys", "Jay-Z", "Kendrick Lamar", "Frank Ocean", "Glass Oceans", "The Beatles", "David Bowie", "Adele", "Lil Nas X", "Sam Smith", "Harry Styles", "Lana Del Rey", "Joji", "Steve Lacy", "Nicki Minaj", "Maroon 5", "Lady Gaga", "Tyler, The Creator"};
  string[] interests = {"Rugby", "Football", "Skiing", "Snowboarding", "E-Sports", "Motor Sports", "Festivals", "Tattoos", "Walking", "K-Pop", "Instagram", "Reading", "Sports", "Clubbing", "Shopping", "Brunch", "Boba Tea", "Cars", "Badminton", "Boxing", "Self Care", "Travel", "Basketball", "Running", "Sushi", "Social Media", "Gym", "Skincare", "Movies", "Coffee", "Singing", "Karaoke", "Feminism", "Road Trips", "Cheerleading", "Cosplay", "Binge-watching TV shows", "Museum", "Art", "Dancing", "Iced Tea", "Board Games", "Tea", "Wine", "Manga", "Makeup", "Writing", "Marvel", "Volleyball", "Memes", "Hiking", "Concerts", "Fashion", "Camping", "Baking", "Anime", "Cycling", "Comedy", "Music", "Disney", "Outdoors", "TikTok", "Netflix", "Swimming", "Working out", "(Hot) Yoga", "90s Britpop", "Black Lives Matter", "Equestrian"};
  string[] yeets ={"Anthem OR Top Artists == Rick Astley", "Bald", "Plays League of Legends", "Goes to University of Sussex", "Flexes Calvin Klein underwear", "Matching bag, outfit, phone and hair colour", "Over 1.5 toilets visible in background of 1 photo", "Has song called Creep on profile", "Has one of top 10 landmarks in a photo", "Pose with cardboard cutout", "Has partner", "Phone charging cable visible", "Is called Anastasiia"};
  [SerializeField]
  GameObject name;
  [SerializeField]
  GameObject distance;
  [SerializeField]
  GameObject university;
  [SerializeField]
  GameObject photoStyle;
  [SerializeField]
  GameObject appearance;
  [SerializeField]
  GameObject bio;
  [SerializeField]
  GameObject drinkChoice;
  [SerializeField]
  GameObject dietaryChoice;
  [SerializeField]
  GameObject smokingChoice;
  [SerializeField]
  GameObject starSign;
  [SerializeField]
  GameObject textingStyle;
  [SerializeField]
  GameObject anthem;
  [SerializeField]
  GameObject topSpotifyArtist;
  [SerializeField]
  GameObject interest;
  [SerializeField]
  GameObject yeet;
  GameObject[] texts;
  string[][] options;
  int[] numberOfDraws;
  [SerializeField]
  Text scoreText;
  int score = 0;


  void Awake() {
    GameObject[] txts = {name, distance, university, photoStyle, appearance, bio, drinkChoice, dietaryChoice, smokingChoice, starSign, textingStyle, anthem, topSpotifyArtist, interest, yeet};
    texts = txts;
    string[][] optns = {names, distances, universities, photoStyles, appearances, bios, drinkChoices, dietaryChoices, smokingChoices, starSigns, textingStyles, anthems, topSpotifyArtists, interests, yeets};
    options = optns;
    int[] noOfDraws = {1, 1, 1, 4, 1, 4, 1, 1, 1, 1, 1, 1, 5, 5, 1};
    numberOfDraws = noOfDraws;
    scoreText.text = score.ToString();
  }

  public void OnButtonClick() {
    Random gen = new Random();
    for (int i = 0; i < options.Length; i++) {
      Dropdown currGameObject = texts[i].GetComponentsInChildren<Dropdown>()[0];
      currGameObject.ClearOptions();
      List<string> chosen = new List<string>();
      for (int j = 0; j < numberOfDraws[i]; j++) {
        string newOption = options[i][gen.Next(0, options[i].Length)];
        while (chosen.Contains(newOption)) {
          newOption = options[i][gen.Next(1, options[i].Length)];
        }
        chosen.Add(newOption);
      }
      currGameObject.AddOptions(chosen);
    }
  }

  public void ScorePlus(int amount) {
    score += amount;
    scoreText.text = score.ToString();
  }

  public void ScoreReset() {
    score = 0;
    scoreText.text = score.ToString();
  }
}
