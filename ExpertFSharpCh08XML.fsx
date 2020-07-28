//  ExpertFSharpCh08XML.fsx 
// see: http://fsharp.github.io/FSharp.Data/library/XmlProvider.html 

// #r @"C:\Users\ellam\.nuget\packages\fsharp.data\3.3.3\lib\net45\FSharp.Data.dll" ;;
#r @"C:\Users\ellam\.nuget\packages\fsharp.data\3.3.3\lib\netstandard2.0\FSharp.Data.dll" ;;

open FSharp.Data ;; 


[<Literal>]
let CustomersXmlSample = """
  <Customers> 
    <Customer name="ACME"> 
      <Order Number="A012345"> 
        <OrderLine Item="widget" Quantity="1"/> 
      </Order> 
      <Order Number="A012346"> 
        <OrderLine Item="trinket" Quantity="2"/> 
      </Order>       
     </Customer>     
    <Customer name="Southwind"> 
      <Order Number="A012347"> 
        <OrderLine Item="skyhook" Quantity="3"/> 
        <OrderLine Item="gizmo" Quantity="4"/> 
      </Order>       
     </Customer>     
   </Customers>""" ;;

type InputXml = XmlProvider<CustomersXmlSample> ;;
let inputs = InputXml.GetSample().Customers ;; 
let orders = 
    [ for customer in inputs do 
        for order in customer.Orders do 
            for line in order.OrderLines do 
                yield (customer.Name, order.Number, line.Item, line.Quantity) ] ;;

[<Literal>]
let OrderLinesXmlSample = """
  <Orderlines>
    <OrderLine Customer="ACME" Order="A012345" Item="widget" Quantity="1"/> 
    <OrderLine Customer="ACME" Order="A012345" Item="trinket" Quantity="2"/> 
    <OrderLine Customer="Southwind" Order="A012347" Item="skyhook" Quantity="3"/> 
    <OrderLine Customer="Southwind" Order="A012347" Item="gizmo" Quantity="4"/> 
  </Orderlines>""" ;;

type OutputXml = XmlProvider<OrderLinesXmlSample> ;;
let orderLines = 
    OutputXml.Orderlines 
        [|  for (name, number, item, quantity) in orders do 
            yield OutputXml.OrderLine(name, number, item, quantity) |] ;; 

orderLines.XElement.ToString() ;; 
