class Skyscraper{

    Story[] stories;

    public Story this [int index] {

        get { return stories[index]; }
        set {

            if(value != null)
            stories[index] = value;
        }

    }

}

