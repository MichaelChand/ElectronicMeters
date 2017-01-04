# ElectronicMeters
While engaged in Software development now, I have background in electronic engineering also.
There are many measuring devices used for various things in the engineering discipline.
I decided to start a project trying to replicate their behaviour.
I am starting with a basic galvanometer. In the physical form a Galvanometer can be modified to represent
many different behaviours such as voltmeter, ammeter, VU, etc. So similarly this user control can be modified
to represent various data such as progress indicator, etc. 

To use it simply compile the project to create the DLL. 
Then in your WPF application add a reference to the dll.
Then use it as below example:
        <Grid Margin="10,10,0,0">
            <Electronic:Galvanometer x:Name="gvGalvo" Title="Progress meter" Width="200" Height="120" Max="100" Min="0" DeltaValue="{Binding DValue, ElementName=WPFComponentTesterWindow, FallbackValue=0}"/>
        </Grid>
        <Button x:Name="btnUpdate" Content="Update" HorizontalAlignment="Left" Margin="10,289,0,0" VerticalAlignment="Top" Width="75" Click="btnUpdate_Click"/>

Remember to add the namespace "ElectronicMeters" first in your XAML document.

Max and Min are the ranges you want to represent. DeltaValue is the change in input you want to represent.

This is work in progress. This push has the basics working but needs more work.
