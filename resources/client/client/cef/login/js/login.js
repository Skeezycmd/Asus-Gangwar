    alt.on('ErrorMessage', (txt) => WarnungSetzen(txt));
    function Login() 
    {
	let name = document.getElementById("name").value;
        {
	     alt.emit('Auth.Login', name);
        }
    }
    function Register() 
    {
	let name = document.getElementById("name").value;

        if(name.length < 3) 
        {
        } 
        else 
        {
	    {
	    	alt.emit('Auth.Register', name);
	    }
        }
    }