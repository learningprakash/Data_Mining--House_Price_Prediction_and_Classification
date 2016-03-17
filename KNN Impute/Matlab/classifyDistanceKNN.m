function [price]= classifyDistanceKNN(k)

  originalData = load('training_data.txt');
  testingdata = load('Test_Data.txt');
  pricevalues = load('Training_Data_AttPrice.txt');
  
  copyTrainLabels = zeros(k,1);  % zero is inbuilt function for creating array
  copyDistances = zeros(k,1);
 
   [m n]=size(originalData); % count as m rows and n as columns in text file
   
   [p q] = size(testingdata);
    price = zeros(p,1); 
   distancetArray = zeros(m,1);
   %[TestRowNo] = (testingdata);
 for j=1:p
   for i=1: m
     distancetArray(i) = calculateDistance(originalData, testingdata,i,n,j);
   end;
  
  
   
   %find k-smallest distances from the above calculated
   %distancesArray
   [sortedCA,indexArray]=sort(distancetArray);
   %sortedCA containsdistances in ascending order.
   %indexArray contains corresponding indecies.
   sumOtherPrices =0.0;
    for i=1:k
        copyDistances(i)=sortedCA(i);
        copyTrainLabels(i)=indexArray(i);
        copyDistances(i)= 1/copyDistances(i);
        sumOtherPrices = sumOtherPrices + copyDistances(i); %denominator for weighted avg value
    end;
    
    for i=1:k
        copyDistances(i)=copyDistances(i)/ (sumOtherPrices) ;
    end;
        
    price(j) = calculatePrice(copyTrainLabels,copyDistances,pricevalues,k);
    
end
   % Calculate mean Price Value
   
  function [Price]=calculatePrice(copyTrainLabels,copyDistances,pricevalues,k)
           sumPrices=0.0;
    
        for i=1:k
        sumPrices = sumPrices + (copyDistances(i)* pricevalues(copyTrainLabels(i)));
        Price = sumPrices;
        end;
        

 
             
  function [dist]=calculateDistance(OriginaldataMatrix,TestingdataMatrix,rowIndex,cols,j)
           sumDistance=0.0;
         
           for i=1:cols
               d=(OriginaldataMatrix(rowIndex,i)-TestingdataMatrix(j,i));
               sumDistance=sumDistance + (d*d);
               dist=sqrt(sumDistance);
           end;
          
   
  
  %function classifyDistancesKNN ends here.            
               
               
               
               
