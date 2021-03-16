class Skyscraper{

    Story[] stories;

    public Story this [int index] {

        get { return stories[index]; }
        set {

            if(value != null)
            sotries[index] = value;
        }

    }

}

Skyscraper empireState = new Skyscraper();
empireState[102] = new Story("The Top one");