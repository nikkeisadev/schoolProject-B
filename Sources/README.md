# JavaScript sources:
### Reading files context.
        document.getElementById('inputfile') 
            .addEventListener('change', function() { 
              
            var fr=new FileReader(); 
            fr.onload=function(){ 
                document.getElementById('output') 
                        .textContent=fr.result; 
            } 
              
            fr.readAsText(this.files[0]); 
        }) 
